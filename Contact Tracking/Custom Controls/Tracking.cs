﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.QrCode;

namespace Contact_Tracking.Custom_Controls
{
    public partial class TrackingTab : UserControl
    {
        public PersonListItem _active_personListItem;
        public PersonListItem active_personListItem
        {
            get { return _active_personListItem; }
            set
            {
                _active_personListItem = value;

                foreach (PersonListItem item in this.PersonList.Controls)
                {
                    if (value != item)
                    {
                        item.nameLabel.BackColor = Color.Transparent;
                    }
                    else
                    {
                        item.nameLabel.BackColor = SystemColors.Highlight;
                    }
                }
            }
        }

        public TrackingTab()
        {
            InitializeComponent();
            DateLabel.Text = DateTime.Now.ToString("D");
        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VisitorList_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in VisitorList.Controls)
            {
                ctrl.Size = new Size(VisitorList.Width, ctrl.Height);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.active_personListItem != null)
            {
                PersonListItem ctrl = this.active_personListItem;
                if (ctrl.person != null) 
                {
                    ctrl.person.AddVisit();
                }

                this.active_personListItem = null;
            }

        }

        private void PersonList_Layout(object sender, LayoutEventArgs e)
        {
            var offset = 0;
            if (PersonList.Controls.Count * 20 > PersonList.Height)
            {
                offset = 20;
            }
            foreach (Control ctrl in PersonList.Controls)
                {
                    ctrl.Size = new Size(PersonList.Width - offset, ctrl.Height);
                }
        }

        private void TrackingTab_Load(object sender, EventArgs e)
        {
        }

        private void QR_Button_Click(object sender, EventArgs e)
        {
            if (!qrCodeReader.Visible)
            {
                qrCodeReader.Location = new Point((this.Width - qrCodeReader.Width) / 2 , (this.Height - qrCodeReader.Height) / 2);
                qrCodeReader.Show();
                qrCodeReader.StartQR();
            }
            else
            {
                qrCodeReader.Hide();
                qrCodeReader.StopQR();
            }
        }

        private void TrackingTab_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rightClick_Menu.Bounds.Contains(e.Location))
            {
               rightClick_Menu.Visible = false;
            }
        }

        private void PersonList_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rightClick_Menu.Bounds.Contains(e.Location))
            {
                rightClick_Menu.Visible = false;
            }
        }

        private void VisitorList_MouseDown(object sender, MouseEventArgs e) 
        {
            if (!rightClick_Menu.Bounds.Contains(e.Location))
            {
                rightClick_Menu.Visible = false;
            }
        }

        private void VisitorList_ControlAdded(object sender, ControlEventArgs e)
        {
            Count_Label.Text = VisitorList.Controls.Count + "/" + Properties.Settings.Default.MaxVisits;

            var offset = 0;
            if (VisitorList.Controls.Count * 20 > VisitorList.Height)
            {
                offset = 20;
            }

            foreach (Control ctrl in VisitorList.Controls)
            {
                ctrl.Size = new Size(VisitorList.Width - offset, ctrl.Height);
            }
        }

        private void VisitorList_ControlRemoved(object sender, ControlEventArgs e)
        {
            Count_Label.Text = VisitorList.Controls.Count + "/" + Properties.Settings.Default.MaxVisits;

            var offset = 0;
            if (VisitorList.Controls.Count * 20 > VisitorList.Height)
            {
                offset = 20;
            }

            foreach (Control ctrl in VisitorList.Controls)
            {
                ctrl.Size = new Size(VisitorList.Width - offset, ctrl.Height);
            }
        }

        private void FilterBox_TextChanged(object sender, EventArgs e)
        {
            foreach (PersonListItem ctrl in PersonList.Controls)
            {
                if (ctrl.person != null && (ctrl.person.FirstName.Contains(this.FilterBox.Text, StringComparison.OrdinalIgnoreCase) || ctrl.person.LastName.Contains(this.FilterBox.Text, StringComparison.OrdinalIgnoreCase)))
                {
                    ctrl.Show();
                }
                else
                {
                    ctrl.Hide();
                }
            }
        }
    }
}
