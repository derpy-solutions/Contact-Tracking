using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Tracking.CustomControls
{
    public partial class RunPopUp : UserControl
    {
        public Action run_default;
        public Action run_Button1;
        public Action run_Button2;

        public string _TextValue;
        public string _Button1_Text;
        public string _Button2_Text;
        public int result;
        public string _Text
        {
            get {
                return _TextValue;
            }
            set {
                _TextValue = value;
                this.ContentSmall.Text = _TextValue;
                this.ContentBig.Text = _TextValue;
            }
        }
        
        public string _Button1
        {
            get {
                return _Button1_Text;
            }
            set {
                _Button1_Text = value;
                this.Button1.Text = "   " + _Button1_Text;
            }
        }
        
        public string _Button2
        {
            get {
                return _Button2_Text;
            }
            set {
                _Button2_Text = value;
                this.Button2.Text = "   " + _Button2_Text;
            }
        }

        public RunPopUp()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (run_Button1 != null)
            {
                if (!passwordPanel.Visible || textBox1.Text == Properties.Settings.Default.Password)
                {
                    run_Button1();
                }
            }

            Reset();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (run_Button2 != null)
            {
                if (!passwordPanel.Visible || textBox1.Text == Properties.Settings.Default.Password)
                {
                    run_Button2();
                }
            }

            Reset();
        }

        private void Reset()
        {
            Hide();
            _Button1 = "Button1";
            Button1.Image = Properties.Resources.stop;
            run_Button1 = null;

            _Button2 = "Button2";
            Button1.Image = Properties.Resources.checkmark;
            run_Button2 = null;

            _Text = "Text";
            textBox1.Text = null;

            Width = 550;
            Height = 275;

            passwordPanel.Hide();
        }

        private void RunPopUp_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (passwordPanel.Visible)
                {
                    textBox1.Focus();
                }
            }
            else
            {
                Reset();
            }
        }

        private void passwordPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (passwordPanel.Visible)
            {
                ContentBig.Hide();
                ContentSmall.Show();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (run_default != null)
                {
                    if (!passwordPanel.Visible || textBox1.Text == Properties.Settings.Default.Password)
                    {
                        run_default();
                    }

                    Reset();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
