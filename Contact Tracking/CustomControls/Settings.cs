using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace Contact_Tracking.Custom_Controls
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            Language_Combo.Items.Add("Deutsch");
            Language_Combo.Items.Add("English");
            switch (Properties.Settings.Default.Language)
            {
                case "en-US":
                    Language_Combo.SelectedItem = "English";
                    break;
                case "de-DE":
                    Language_Combo.SelectedItem = "Deutsch";
                    break;
            }

            ShowTooltip_Toggle.setChecked(Properties.Settings.Default.ShowTooltips);
            CheckUpdates_Toggle.setChecked(Properties.Settings.Default.CheckForUpdates);
            ShowBadge_Toggle.setChecked(Properties.Settings.Default.ShowBadge);
            SaveVisit_Toggle.setChecked(Properties.Settings.Default.SaveVisits);
            requirePW_Toggle.setChecked(Properties.Settings.Default.RequirePassword);
            SaveStats_Toggle.setChecked(Properties.Settings.Default.SaveStats);
            FlipCamera_Toggle.setChecked(Properties.Settings.Default.FlipCamera);

            Vaccinated_Num.Value = Properties.Settings.Default.Corona_VaccinatedDuration;
            Tested_Num.Value = Properties.Settings.Default.Corona_TestedDuration;
            MinAgeText_Num.Value = Properties.Settings.Default.Corona_MinAgeTest;
            SecurityKey_textBox.Text = Properties.Settings.Default.SecurityKey;
            Password_textBox.Text = Properties.Settings.Default.Password;
            VisitDays_Num.Value = Properties.Settings.Default.VisitDaysSave;
            MaxVisits_Num.Value = Properties.Settings.Default.MaxVisits;
            StatDays_Num.Value = Properties.Settings.Default.Stats_DaysToSave;
            ShowStatDays_Num.Value = Properties.Settings.Default.Stats_DaysToShow;
            DataPath_TxtBx.Text = Properties.Settings.Default.DataPath;
            PeopleSaveDays_num.Value =Properties.Settings.Default.PersonIdleDays;

            SplitLog_Toggle.setChecked(Properties.Settings.Default.SplitLog);
            SplitLogAt_Picker.Value = DateTime.Parse("01.01.1900 " + Properties.Settings.Default.SplitLogAt);

            SplitStats_Toggle.setChecked(Properties.Settings.Default.SplitStats);
            SplitStatsAt_Picker.Value = DateTime.Parse("01.01.1900 " + Properties.Settings.Default.SplitStatsAt);

            Language.Actions.Add(new Language.Entry() { action = LoadLanguage, name = "Settings", initialized = true});
        }

        public void LoadLanguage()
        {
            Label_Settings.Text = Properties.strings.Settings;
            Label_UI.Text = Properties.strings.UserInterface;
            Label_Language.Text = Properties.strings.Language;
            Label_ShowTooltips.Text = Properties.strings.Show_ToolTips;
            FlipCamera_Label.Text = Properties.strings.FlipCamera;
            Label_Updates.Text = Properties.strings.Update;
            Label_CheckUpdates.Text = Properties.strings.CheckUpdates;
            Label_DataPath.Text = "Data" + Properties.strings.Path;

            Label_Security.Text = Properties.strings.Security;
            Label_SecurityDescription.Text = Properties.strings.SecurityDescription;
            Label_SecurityKey.Text = Properties.strings.SecurityKey;
            GenerateKey_Btn.Text = Properties.strings.GenerateNew;
            Label_Password.Text = Properties.strings.Password;
            Label_RequirePassword.Text = Properties.strings.RequirePassword;
                       
            Label_PersonalData.Text = Properties.strings.PersonalData;
            Label_PersonalDataDescription.Text = Properties.strings.PersonalDataDescription;
            Label_PeopleSaveDays.Text = Properties.strings.DaysToSave;
            PeopleWipe_Btn.Text = Properties.strings.WipePeople;

            Label_Statistics.Text = Properties.strings.Statistics;
            Label_StatisticsDescription.Text = Properties.strings.StatDescription;
            SplitStats_Label.Text = Properties.strings.SplitStats;
            SplitStatsAt_Label.Text = Properties.strings.SplitStatsAt;
            Label_SaveStatistic.Text = Properties.strings.SaveStats;
            Label_StatDays.Text = Properties.strings.DaysToSave;
            Label_StatDaysShow.Text = Properties.strings.DaysToShow;
            WipeStats_Btn.Text = Properties.strings.WipeStats;

            Label_Visit.Text = Properties.strings.Visitors;
            Label_VisitDescription.Text = Properties.strings.VisitsDescription;
            SplitLog_Label.Text = Properties.strings.SplitLog;
            SplitLogAt_Label.Text = Properties.strings.SplitLogAt;
            Label_SaveVisit.Text = Properties.strings.SaveVisitors;
            Label_VisitDays.Text = Properties.strings.DaysToSave;
            Label_MaxVisits.Text = Properties.strings.MaxVisists;
            WipeVisits_Btn.Text = Properties.strings.WipeVisits;

            Label_CoronaSettings.Text = Properties.strings.Covid;
            Label_CoronaDescription.Text = Properties.strings.CovidDescription;
            Label_ShowBadge.Text = Properties.strings.ShowBadge;
            Label_Corona_VaccinatedDuration.Text = Properties.strings.VaccinatedDuration;
            Label_Corona_TestedDuration.Text = Properties.strings.TestedDuration;
            Label_NoTestAge.Text = Properties.strings.MinAge;

            ResetSettings_Btn.Text = Properties.strings.ResetSettings;
        }

        private void Language_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Language_Combo.SelectedItem != null)
            {
                switch (Language_Combo.SelectedItem)
                {
                    case "English":
                        Properties.Settings.Default.Language = "en-US";
                        Language.Load();
                        break;
                    case "Deutsch":
                        Properties.Settings.Default.Language = "de-DE";
                        Language.Load();
                        break;
                }

                Properties.Settings.Default.Save();
            }
        }

        private void ShowTooltip_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowTooltips = ShowTooltip_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }

        private void CheckUpdates_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdates = CheckUpdates_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }

        private void ShowBadge_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowBadge = ShowBadge_Toggle.isChecked();
            Properties.Settings.Default.Save();
            MyControls.TrackingTab.PersonList.Update();
        }

        private void SaveVisit_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveVisits = SaveVisit_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }

        private void requirePW_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.RequirePassword = requirePW_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }

        private void SaveStats_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveStats = SaveStats_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    DataPath_TxtBx.Text = fbd.SelectedPath;
                    Properties.Settings.Default.DataPath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            void Reset()
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
            }
            var pUp = MyControls.Main.runPopUp;

            pUp.passwordPanel.Show();
            pUp.Height = 175;
            pUp.Width = 250;

            pUp._Text = "";

            pUp._Button1 = Properties.strings.No;
            pUp.run_Button1 = null;
            pUp.Button1.Image = Properties.Resources.stop;

            pUp._Button2 = Properties.strings.Yes;
            pUp.run_Button2 = Reset;
            pUp.Button2.Image = Properties.Resources.checkmark;

            pUp.run_default = Reset;
            pUp.Location = new Point((MyControls.Main.Width - pUp.Width) / 2, (MyControls.Main.Height - pUp.Height) / 2);
            pUp.Show();
        }

        private void DataPath_TxtBx_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DataPath = DataPath_TxtBx.Text;
            Properties.Settings.Default.Save();
        }

        private void GenerateKey_Btn_Click(object sender, EventArgs e)
        {
            void run_Button1()
            {
                ConsoleEx.WriteLine("Change Encryption Key!");
                Aes aes = Aes.Create();

                Properties.Settings.Default.SecurityKey = Convert.ToBase64String(aes.Key);
                Properties.Settings.Default.SecurityIV = Convert.ToBase64String(aes.IV);
                Properties.Settings.Default.Save();

                this.SecurityKey_textBox.Text = Properties.Settings.Default.SecurityKey;

                foreach (Person person in G.People)
                {
                    person.Save();
                }

                SQL.WipeLogs();
                SQL.CreateLogsTable();

                foreach (Person person in G.People)
                {
                    if (person.visitorItem != null)
                    {
                        person.visitorItem.Dispose();
                        person.visitorItem = null;
                    }

                    person.VisitTime = null;
                }
            }
            void run_Button2()
            {
                ConsoleEx.WriteLine("Do Nothing!");
            }

            var pUp = MyControls.Main.runPopUp;

            pUp.Width = 550;
            pUp.Height = 275;

            pUp.passwordPanel.Show();

            pUp._Text = "You will loose all your visit logs. Make sure to export them if you need the data." + Environment.NewLine + Environment.NewLine + "This action can not be undone." + Environment.NewLine + "Are you sure to perform this action?";

            pUp._Button1 = Properties.strings.Yes;
            pUp.run_Button1 = run_Button1;
            pUp.Button1.Image = Properties.Resources.checkmark;

            pUp._Button2 = Properties.strings.No;
            pUp.run_Button2 = run_Button2;
            pUp.Button2.Image = Properties.Resources.stop;

            pUp.Location = new Point((MyControls.Main.Width - pUp.Width) / 2, (MyControls.Main.Height - pUp.Height) / 2);
            pUp.Show();
        }

        private void FlipCamera_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.FlipCamera = FlipCamera_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }

        private void VisitDays_Num_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VisitDaysSave = Convert.ToInt32(VisitDays_Num.Value);
            Properties.Settings.Default.Save();
        }

        private void MaxVisits_Num_ValueChanged(object sender, EventArgs e)
        {
            if (Main.initialized)
            {
                Properties.Settings.Default.MaxVisits = Convert.ToInt32(MaxVisits_Num.Value);
                MyControls.TrackingTab.Count_Label.Text = MyControls.TrackingTab.VisitorList.Controls.Count + "/" + Properties.Settings.Default.MaxVisits;
                Properties.Settings.Default.Save();
            }
        }

        private void Vaccinated_Num_ValueChanged(object sender, EventArgs e)
        {
            if (Main.initialized)
            {
                Properties.Settings.Default.Corona_VaccinatedDuration = Convert.ToInt32(Vaccinated_Num.Value);
                Properties.Settings.Default.Save();

                foreach (Person p in G.People)
                {
                    p.RefreshCovid();
                }
            }
        }

        private void Tested_Num_ValueChanged(object sender, EventArgs e)
        {
            if (Main.initialized)
            {
                Properties.Settings.Default.Corona_TestedDuration = Convert.ToInt32(Tested_Num.Value);
                Properties.Settings.Default.Save();

                foreach (Person p in G.People)
                {
                    p.RefreshCovid();
                }
            }
        }

        private void MinAgeText_Num_ValueChanged(object sender, EventArgs e)
        {
            if (Main.initialized)
            {
                Properties.Settings.Default.Corona_MinAgeTest = Convert.ToInt32(MinAgeText_Num.Value);
                Properties.Settings.Default.Save();

                foreach (Person p in G.People)
                {
                    p.RefreshCovid();
                }
            }
        }

        private void StatDays_Num_ValueChanged(object sender, EventArgs e)
        {
            if (Main.initialized)
            {
                Properties.Settings.Default.Stats_DaysToSave = Convert.ToInt32(StatDays_Num.Value);
                Properties.Settings.Default.Save();
            }
        }

        private void ShowStatDays_Num_ValueChanged(object sender, EventArgs e)
        {
            if (Main.initialized)
            {
                Properties.Settings.Default.Stats_DaysToShow = Convert.ToInt32(ShowStatDays_Num.Value);
                Properties.Settings.Default.Save();
            }
        }

        private void WipeStats_Btn_Click(object sender, EventArgs e)
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
            pUp.run_Button2 = SQL.WipeStats;
            pUp.Button2.Image = Properties.Resources.checkmark;

            pUp.run_default = SQL.WipeStats;
            pUp.Location = new Point((MyControls.Main.Width - pUp.Width) / 2, (MyControls.Main.Height - pUp.Height) / 2);
            pUp.Show();
        }

        private void WipeVisits_Btn_Click(object sender, EventArgs e)
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
            pUp.run_Button2 = SQL.WipeLogs;
            pUp.Button2.Image = Properties.Resources.checkmark;

            pUp.run_default = SQL.WipeLogs;
            pUp.Location = new Point((MyControls.Main.Width - pUp.Width) / 2, (MyControls.Main.Height - pUp.Height) / 2);
            pUp.Show();
        }

        private void Password_textBox_Click(object sender, EventArgs e)
        {
            void EditPassword()
            {
                Password_textBox.Focus();
                Password_textBox.ReadOnly = false;
                this.Password_textBox.PasswordChar = '\0';
            }
            var pUp = MyControls.Main.runPopUp;

            pUp.passwordPanel.Show();
            pUp.Height = 175;
            pUp.Width = 250;

            pUp._Text = "";

            pUp._Button1 = Properties.strings.No;
            pUp.run_Button1 = null;
            pUp.Button1.Image = Properties.Resources.stop;

            pUp._Button2 = Properties.strings.Yes;
            pUp.run_Button2 = EditPassword;
            pUp.Button2.Image = Properties.Resources.checkmark;

            pUp.run_default = EditPassword;
            pUp.Location = new Point((MyControls.Main.Width - pUp.Width) / 2, (MyControls.Main.Height - pUp.Height) / 2);
            pUp.Show();
        }

        private void Password_textBox_Leave(object sender, EventArgs e)
        {
            this.Password_textBox.Text = Properties.Settings.Default.Password;
            Password_textBox.ReadOnly = true;
            //this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.PasswordChar = '*';
            //Password_textBox.PasswordChar = " * ";
        }

        private void Password_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Properties.Settings.Default.Password = this.Password_textBox.Text;
                Properties.Settings.Default.Save();

                this.Focus();
                this.Password_textBox.PasswordChar = '*';
                Password_textBox.ReadOnly = true;
            }
        }

        private void PeopleSaveDays_num_ValueChanged(object sender, EventArgs e)
        {
            if (Main.initialized)
            {
                Properties.Settings.Default.PersonIdleDays = Convert.ToInt32(PeopleSaveDays_num.Value);
                Properties.Settings.Default.Save();
            }
        }

        private void PeopleWipe_Btn_Click(object sender, EventArgs e)
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
            pUp.run_Button2 = SQL.WipePeople;
            pUp.Button2.Image = Properties.Resources.checkmark;

            pUp.run_default = SQL.WipePeople;
            pUp.Location = new Point((MyControls.Main.Width - pUp.Width) / 2, (MyControls.Main.Height - pUp.Height) / 2);
            pUp.Show();
        }

        private void SplitLog_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.SplitLog = SplitLog_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }

        private void SplitLogAt_Picker_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SplitLogAt = SplitLogAt_Picker.Value.ToString("t");
            Properties.Settings.Default.Save();
        }

        private void SplitStatsAt_Picker_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SplitStatsAt = SplitStatsAt_Picker.Value.ToString("t");
            Properties.Settings.Default.Save();
        }

        private void SplitStats_Toggle__Clicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.SplitStats = SplitStats_Toggle.isChecked();
            Properties.Settings.Default.Save();
        }
    }
}
