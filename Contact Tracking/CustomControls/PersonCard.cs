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
            Language.Actions.Add(LoadLanguage);

            Tested_Picker.Value = DateTime.Parse("01.01.1900");
            Vaccinated_Picker.Value = DateTime.Parse("01.01.1900");
            DateOfBirth_Picker.Value = DateTime.Parse("01.01.1900");
        }

        public void LoadLanguage()
        {
            New_Button.Text = "  " + Properties.strings.New;
            PersonID.Text = Properties.strings.PersonalID;
            Label_FirstName.Text = Properties.strings.FirstName;
            Label_LastName.Text = Properties.strings.LastName;
            Label_DateOfBirth.Text = Properties.strings.DateOfBirth;
            Label_Address.Text = Properties.strings.Address;
            Label_Phone.Text = Properties.strings.Phone;
            Label_EMail.Text = Properties.strings.EMail;
            Label_Note.Text = Properties.strings.Note;
            Delete.Text = "  " + Properties.strings.DeletePerson;

            Statistics_Label.Text = Properties.strings.Statistics;
            Label_Gender.Text = Properties.strings.Gender;
            Label_AgeGroup.Text = Properties.strings.AgeGroup;
            Migration_ChckBx._Text = Properties.strings.migration_background;

            QRCode_Label.Text = Properties.strings.QRCode;
            CreateQR_Button.Text = "  " + Properties.strings.Save;

            Label_CoronaProof.Text = Properties.strings.CoronaProof;
            Label_Tested.Text = Properties.strings.Tested;
            Label_Vaccinated.Text = Properties.strings.Vaccinated;

            Save.Text = "  " + Properties.strings.Save;
            Discard.Text = "  " + Properties.strings.ResetChanges;

            GenderCombo.Items.Clear();
            GenderCombo.Items.Add(Properties.strings.divers);
            GenderCombo.Items.Add(Properties.strings.female);
            GenderCombo.Items.Add(Properties.strings.male);

            GenderCombo.SelectedItem = Properties.strings.divers;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                person.FirstName = temp.FirstName;
                person.LastName = temp.LastName;
                person.DateOfBirth = temp.DateOfBirth;
                person.Address = temp.Address;
                person.Phone = temp.Phone;
                person.EMail = temp.EMail;
                person.Note = temp.Note;

                person.MigrationBackground = temp.MigrationBackground;
                person.AgeCategory = temp.AgeCategory;
                person.Gender = temp.Gender;

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

                Tested_Picker.Value = DateTime.Parse("01.01.1900");
                Vaccinated_Picker.Value = DateTime.Parse("01.01.1900");
                DateOfBirth_Picker.Value = DateTime.Parse("01.01.1900");

                Address_TextBox.Text = null;
                EMail_TextBox.Text = null;
                Note_TextBox.Text = null;
                Phone_TextBox.Text = null;
                PersonID.Text = Properties.strings.PersonalID + ": " + 0;
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

        private void GenderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (person != null && GenderCombo.SelectedItem != null)
            {
                switch (GenderCombo.SelectedItem)
                {
                    case "männlich":
                        temp.Gender = "male";
                        break;
                    case "divers":
                        temp.Gender = "divers";
                        break;
                    case "weiblich":
                        temp.Gender = "female";
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
                temp.AgeCategory = null;

                AgeCategory_Combo.SelectedItem = temp.getAgeCategory();
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
            if (this.Visible && this.FirstName_TextBox.Text != null && this.FirstName_TextBox.Text != "")
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

        private void Migration_ChckBx__Clicked(object sender, EventArgs e)
        {
            temp.MigrationBackground = Migration_ChckBx.isChecked();
            FlashSaveButton();
            QR_Code.Image = temp.QRCode;
        }

        private void AgeCategory_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AgeCategory_Combo.SelectedIndex > -1)
            {
                temp.AgeCategory = AgeCategory_Combo.SelectedItem.ToString();
                FlashSaveButton();
            }
        }

        private void Clear_Tested_Click(object sender, EventArgs e)
        {
            Tested_Picker.Value = DateTime.Parse("01.01.1900");
            temp.Tested = null;
        }

        private void Clear_Vaccinated_Click(object sender, EventArgs e)
        {
            Vaccinated_Picker.Value = DateTime.Parse("01.01.1900");
            temp.Vaccinated = null;
        }

        private void Clear_DateOfBirth_Click(object sender, EventArgs e)
        {
            DateOfBirth_Picker.Value = DateTime.Parse("01.01.1900");
            temp.DateOfBirth = null;
        }
    }
}
