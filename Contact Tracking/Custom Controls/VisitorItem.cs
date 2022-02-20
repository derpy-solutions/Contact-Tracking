using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contact_Tracking.Custom_Controls
{
    public partial class VisitorItem : UserControl
    {
        public DateTime time;
        public string person_name;
        public Person person;
        public VisitorItem()
        {
            InitializeComponent();
        }

        private void Favorites_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                person.DeleteVisit();
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
