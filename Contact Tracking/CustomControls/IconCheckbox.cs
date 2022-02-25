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
    public partial class IconCheckbox : UserControl
    {
        private bool _checkedValue = false;
        private string _TextValue = "IconCheckbox";
        public bool _checked
        {
            get {
                return _checkedValue;
            }
            set {
                switch (value)
                {
                    case true:
                        this.button1.Image = Properties.Resources.checkbox_checked;
                        _checkedValue = value;
                        break;

                    case false:
                        this.button1.Image = Properties.Resources.checkbox_unchecked;
                        _checkedValue = value;
                        break;
                }
            }
        }
        public string _Text
        {
            get {
                return _TextValue;
            }
            set {
                _TextValue = value;
                this.button1.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when user clicks control")]
        public event EventHandler _Clicked;

        public IconCheckbox()
        {
            InitializeComponent();
        }

        public bool isChecked()
        {
            return _checked;
        }

        public void setChecked(bool state)
        {
            _checked = state;
        }

        private void IconCheckbox_Click(object sender, EventArgs e)
        {
            if (_checked)
            {
                _checked = false;
            }
            else
            {
                _checked = true;
            }

            _Clicked?.Invoke(this, e);
        }
    }
}
