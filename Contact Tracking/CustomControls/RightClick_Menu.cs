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
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Person p = MyControls.TrackingTab.active_personListItem.person;
            p.LoadCard();

            MyControls.PersonTab.person = p;
            MyControls.TrackingTab.Hide();
            MyControls.PersonTab.Show();
        }

        private void AddVisit_Click(object sender, EventArgs e)
        {
            Person p = MyControls.TrackingTab.active_personListItem.person;
            p.AddVisit();
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
