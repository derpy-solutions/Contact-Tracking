using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing.Imaging;

namespace Contact_Tracking.Custom_Controls
{
    public partial class PersonCard : UserControl
    {
        public Person person;
        public Person temp;
        public DateTime timerStart;
        List<Color> flashingColors;
        int colorNum = 0;
        bool increase_Flashing = true; 

        public PersonCard()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                person.FirstName = temp.FirstName;
                person.LastName = temp.LastName;
                person.Sex = temp.Sex;
                person.DateOfBirth = temp.DateOfBirth;
                person.Address = temp.Address;
                person.Phone = temp.Phone;
                person.EMail = temp.EMail;
                person.Note = temp.Note;
                person.Tested = temp.Tested;
                person.Vaccinated = temp.Vaccinated;

                person.Save();
                StopFlash();
            }
        }

    private void CreateQR_Button_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                person.SaveQR();
            }
        }

        private void FirstName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (person != null)
            {
                temp.FirstName = this.FirstName_TextBox.Text;
                QR_Code.Image = temp.QRCode;
                FlashSaveButton();
            }
        }

        private void LastName_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (person != null)
            {
                temp.LastName = this.LastName_TextBox.Text;
                QR_Code.Image = temp.QRCode;
                FlashSaveButton();
            }
        }

        private void Address_TextBox_TextChanged(object sender, EventArgs e)
                {
            if (person != null)
            {
                temp.Address = this.Address_TextBox.Text;
                QR_Code.Image = temp.QRCode;
                FlashSaveButton();
            }
        }

        private void Phone_TextBox_TextChanged(object sender, EventArgs e)
                    {
            if (person != null)
            {
                temp.Phone = this.Phone_TextBox.Text;
                QR_Code.Image = temp.QRCode;
                FlashSaveButton();
            }
        }

        private void EMail_TextBox_TextChanged(object sender, EventArgs e)
                        {
            if (person != null)
            {
                temp.EMail = this.EMail_TextBox.Text;
                QR_Code.Image = temp.QRCode;
                FlashSaveButton();
            }
        }

        private void Note_TextBox_TextChanged(object sender, EventArgs e)
                            {
            if (person != null)
            {
                temp.Note = this.Note_TextBox.Text;
                FlashSaveButton();
            }
        }

        private void New_Button_Click(object sender, EventArgs e)
        {
            person = new Person();
            person.ID = G.LastID + 1;
            person.LoadCard();
        }

        private void PersonCard_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                person.Delete();
                Clear();
            }
        }

        public void Clear()
        {
            if (person != null)
            {
                person = null;
                temp = null;

                FirstName_TextBox.Text = null;
                LastName_TextBox.Text = null;
                DateOfBirth_Picker.Value = DateTime.Now;
                Address_TextBox.Text = null;
                EMail_TextBox.Text = null;
                Note_TextBox.Text = null;
                Phone_TextBox.Text = null;
                PersonID.Text = "Persönliche ID: " + 0;
                QR_Code.Image = MyQRCode.Create(person);
            }

            StopFlash();
        }

        private void PersonCard_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                Clear();
            }
        }

        private void SexCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (person != null && SexCombo.SelectedItem != null)
            {
                switch (SexCombo.SelectedItem)
                {
                    case "männlich":
                        temp.Sex = "male";
                        break;
                    case "divers":
                        temp.Sex = "divers";
                        break;
                    case "weiblich":
                        temp.Sex = "female";
                        break;
                }
                FlashSaveButton();
            }
        }

        private void DateOfBirth_Picker_ValueChanged(object sender, EventArgs e)
        {
            if (person != null)
            {
                temp.DateOfBirth = this.DateOfBirth_Picker.Value.ToString("d");
                FlashSaveButton();
                QR_Code.Image = temp.QRCode;
            }
        }

        private void Tested_Picker_ValueChanged(object sender, EventArgs e)
        {
            if (person != null)
            {
                temp.Tested = this.Tested_Picker.Value.ToString("g");
                FlashSaveButton();
            }
        }

        private void Vaccinated_Picker_ValueChanged(object sender, EventArgs e)
        {
            if (person != null)
            {
                temp.Vaccinated = this.Vaccinated_Picker.Value.ToString("d");
                FlashSaveButton();
            }
        }

        private void Discard_Click(object sender, EventArgs e)
        {
            if (person != null) person.LoadCard();
            StopFlash();
        }

        private void FlashingTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Subtract(timerStart).TotalSeconds < 30)
            {
                if (flashingColors == null)
                {
                    Color start = Color.FromArgb(255, 64, 64, 64);
                    Color end = Color.FromArgb(255, 47, 199, 31);
                    //Color end = Color.FromArgb(255, 70, 128, 64);

                    flashingColors = G.GetGradients(start, end, 25);
                }

                if (colorNum >= flashingColors.Count -1)
                {
                    increase_Flashing = false;
                }
                else if (colorNum <= 0)
                {
                    increase_Flashing = true;
                }

                if (increase_Flashing)
                {
                    colorNum++;
                    Save.BackColor = flashingColors[colorNum];
                }
                else
                {
                    colorNum--;
                    Save.BackColor = flashingColors[colorNum];
                }
            }
            else
            {
                StopFlash();
            }
        }

        private void FlashSaveButton()
        {
            if (this.Visible)
            {
                timerStart = DateTime.Now;
                FlashingTimer.Start();
            }
        }

        private void StopFlash()
        {
            FlashingTimer.Stop();
            flashingColors = null;
            Save.BackColor = Color.FromArgb(255, 64, 64, 64);
        }
    }
}
