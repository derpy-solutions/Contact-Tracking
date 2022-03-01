using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contact_Tracking.Custom_Controls
{
    public partial class RightClick_Menu : UserControl
    {
        public RightClick_Menu()
        {
            InitializeComponent();
            Language.Actions.Add(new Language.Entry() { action = LoadLanguage, name = "Right Click Menu", initialized = true });
        }
        public void LoadLanguage()
        {
            Edit.Text = Properties.strings.Edit;
            AddVisit.Text = Properties.strings.AddVisit;
            CreateQR.Text = Properties.strings.CreateQR;
        }

            private void Edit_Click(object sender, EventArgs e)
        {
            void EditPerson()
            {
                Person p = MyControls.TrackingTab.active_personListItem.person;
                p.LoadCard();

                MyControls.PersonTab.person = p;
                MyControls.TrackingTab.Hide();
                MyControls.PersonTab.Show();
                G.lastPW = DateTime.Now;
            }

            if (G.isPasswordRequired())
            {
                var pUp = MyControls.Main.runPopUp;

                pUp.passwordPanel.Show();
                pUp.Height = 175;
                pUp.Width = 250;

                pUp._Text = "";

                pUp._Button1 = Properties.strings.No;
                pUp.run_Button1 = null;
                pUp.Button1.Image = Properties.Resources.stop;

                pUp._Button2 = Properties.strings.Yes;
                pUp.run_Button2 = EditPerson;
                pUp.Button2.Image = Properties.Resources.checkmark;

                pUp.run_default = EditPerson;
                pUp.Location = new Point((MyControls.Main.Width - pUp.Width) / 2, (MyControls.Main.Height - pUp.Height) / 2);
                pUp.Show();
            }
            else
            {
                EditPerson();
            }
        }

        private void AddVisit_Click(object sender, EventArgs e)
        {
            Person p = MyControls.TrackingTab.active_personListItem.person;
            p.AddVisit();
            p.LastVisit = DateTime.Now.ToString("d");
            p.Save();
            this.Hide();
        }

        private void CreateQR_Click(object sender, EventArgs e)
        {
            Person p = MyControls.TrackingTab.active_personListItem.person;
            p.SaveQR();
            this.Hide();
        }

        private void RightClick_Menu_Leave(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
