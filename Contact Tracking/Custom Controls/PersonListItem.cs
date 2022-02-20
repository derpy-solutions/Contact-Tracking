using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using ZXing.QrCode;
using ZXing.QrCode.Internal;

namespace Contact_Tracking.Custom_Controls
{
    public partial class PersonListItem : UserControl
    {
        public bool focused;
        public bool passed;
        public TrackingTab parentTab;
        public Person person;
        public void setPassed()
        {
            passed = true;
            this.statusImage.Image = Properties.Resources.circle_checkmark_green_16x16;
        }
        public void setFailed()
        {
            passed = false;
            this.statusImage.Image = Properties.Resources.circle_exclamationmark_red_16x16;
        }       
        public void UpdateValues()
        {
            if (this.person != null )
            {
                this.nameLabel.Text = person.FirstName + " " + person.LastName;
                person.RefreshCovid();
            }
        }

        public PersonListItem(TrackingTab ptT)
        {
            parentTab = ptT;
            InitializeComponent();
        }

        private void PersonListItem_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            RightClick_Menu rightClick_Menu = MyControls.TrackingTab.rightClick_Menu;

            switch (me.Button)
            {

                case MouseButtons.Left:
                    rightClick_Menu.Hide();
                   // this.nameLabel.BackColor = SystemColors.Highlight;
                    //this.nameLabel.Focus();
                    break;

                case MouseButtons.Right:
                    var main = MyControls.Main;
                    var tracking = MyControls.TrackingTab;

                    var offset = new Point(MousePosition.X - main.Location.X - tracking.Location.X - 5, MousePosition.Y - main.Location.Y - tracking.Location.Y - this.Height);

                    Console.WriteLine("Show Menu");
                    var pos = offset;
                    rightClick_Menu.Location = pos;
                    rightClick_Menu.personName.Text = person.FullName;
                    rightClick_Menu.Update();
                    rightClick_Menu.Show();
                    rightClick_Menu.Focus();

                    // Right click
                    break;
            }

            parentTab.active_personListItem = this;
        }

        private void PersonListItem_Leave(object sender, EventArgs e)
        {
           // this.nameLabel.BackColor = Color.Transparent;
        }

        private void nameLabel_DoubleClick(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                person.AddVisit();
            }
        }
    }
}
