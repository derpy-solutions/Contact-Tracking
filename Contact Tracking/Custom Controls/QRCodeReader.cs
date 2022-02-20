using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;

namespace Contact_Tracking.Custom_Controls
{
    public partial class QRCodeReader : UserControl
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;

        public QRCodeReader()
        {
            InitializeComponent();
        }

        private void QRTimer_Tick(object sender, EventArgs e)
        {
            if (Camera != null && Camera.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)Camera.Image);
                if (result != null)
                {
                    Console.WriteLine(result);
                    var decrypted = Encryption.Decrypt(result.ToString());
                    QR_Text.Text = "Encrypted: " + Environment.NewLine + result.ToString() + Environment.NewLine +  Environment.NewLine + "Decrypted: " + Environment.NewLine + decrypted;

                    List<string> data = new List<string>();
                    string[] subs = decrypted.Split('|');
                    Console.WriteLine("Split strings:");
                    foreach (var sub in subs)
                    {
                        Console.WriteLine(sub);
                        data.Add(sub);
                    }

                    if (data.Count >= 4)
                    {
                        Console.WriteLine("count passed: " + data.Count);
                        Console.WriteLine("data1: " + data[1] + "; data2: " + data[2] + "; data3:" + data[3]);
                        var found = false;
                        foreach (Person person in G.People)
                        {
                            if (person.FirstName == data[1] &&person.LastName == data[2] && person.DateOfBirth == data[3])
                            {
                                Console.WriteLine("Found '" + person.FirstName + " " + person.LastName + "' in our data base.");
                                person.AddVisit();
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            Person person = new Person();
                            person.FirstName = data[1];
                            person.LastName = data[2];
                            person.Sex = data[3];
                            person.DateOfBirth = data[4];
                            person.Address = data[5];
                            person.Phone = data[6];
                            person.EMail = data[7];
                            person.ID = G.LastID + 1;
                            Console.WriteLine("Add '" + person.FullName + "' with ID: " + person.ID);
                            person.Add();
                            person.Save();
                            person.AddVisit();
                        }
                    }

                    StopQR();
                    this.Hide();
                }
            }
        }

        private void QRCodeReader_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                cboDevice.Items.Add(filterInfo.Name);
                cboDevice.SelectedIndex = 0;
            }
        }
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Camera.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        public void StartQR()
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();

            QRTimer.Start();
        }
        public void StopQR()
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.SignalToStop();
            }

            Camera.Image = null;
            QRTimer.Stop();
        }
    }
}
