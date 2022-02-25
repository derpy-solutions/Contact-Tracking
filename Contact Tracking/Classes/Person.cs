using System;
using System.Globalization;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;
using System.IO;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing;
using System.Drawing.Imaging;

namespace Contact_Tracking
{
    public class Person
    {
        public bool EqualsPerson(Person other)
        {
            if (other == null)
                return false;

            return 
                (
                    this.FirstName == other.FirstName || this.FirstName == null || other.FirstName == null
                ) &&
                (
                    this.LastName == other.LastName || this.LastName == null || other.LastName == null
                ) &&
                (
                    this.DateOfBirth == other.DateOfBirth || this.DateOfBirth == null || other.DateOfBirth == null
                ) &&
                (
                    this.Address == other.Address || this.Address == null || other.Address == null
                ) &&
                (
                    this.Phone == other.Phone || this.Phone == null || other.Phone == null
                ) &&
                (
                    this.EMail == other.EMail || this.EMail == null || other.EMail == null
                );
        }
        private string _QRData;
        public Bitmap QRCode {
            get
            {
                if (_QRData != QRData)
                {
                    _QRCode = MyQRCode.Create(this);
                    _QRData = QRData;
                }

                return _QRCode;
            }
            set
            {
                _QRCode = value;
            }
        }
        public Custom_Controls.PersonListItem listItem;
        public Custom_Controls.VisitorItem visitorItem;
        private Bitmap _QRCode;
        public string FirstName;
        public string LastName;
        public string Gender;
        public string _AgeCategory;
        public string getAgeCategory()
        {
            return AgeCategory;
        }
        public string AgeCategory
        {
            get
            {
                if (_AgeCategory == null || _AgeCategory == "")
                {
                    if (DateOfBirth != null)
                    {
                        DateTime date;
                        if (DateTime.TryParse(DateOfBirth, out date))
                        {

                            switch (G.Years(date, DateTime.Now))
                            {
                                case int n when (n <= 13):
                                    _AgeCategory = "6-13";
                                    break;

                                case int n when (n <= 17):
                                    _AgeCategory = "14-17";
                                    break;

                                case int n when (n > 17):
                                    _AgeCategory = "18+";
                                    break;
                            }
                        }
                    }
                }

                return _AgeCategory;
            }
            set
            {
                _AgeCategory = value;
            }
        }
        public bool MigrationBackground;
        public string DateOfBirth;
        public string Address;
        public string Phone;
        public string EMail;
        public string Note;
        public string Tested;
        public string Vaccinated;
        public string VisitTime;
        public string LastVisit;
        public int ID { get; set; }
        public string FullName {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }
        public int getID{
            get
            {
                if (ID == 0)
                {
                    ID = G.LastID + 1;
                    G.LastID = ID;
                }

                return ID;
            }
        }
        public string QRData {
            get
            {
                return $"derpySolutions|{FirstName}|{LastName}|{DateOfBirth}|{Gender}|{Address}|{Phone}|{EMail}|{MigrationBackground}";
            }
        }
        public string FileName {
            get
            {
                return $"{FirstName} {LastName} - {DateOfBirth}";
            }
        }
        public bool DeleteStat()
        {
            if (G.CurrentStat == null)
            {
                G.LastStatID++;
                G.CurrentStat = new Stat();
                G.CurrentStat.ID = G.LastStatID;
                G.CurrentStat.Add();
            }

            bool update(object obj)
            {
                switch (obj)
                {
                    case Stats.Age_14_17 s14_17:
                        switch (Gender)
                        {
                            case "female":
                                s14_17.female--;
                                return true;

                            case "male":
                                s14_17.male--;
                                return true;

                            case "divers":
                                s14_17.divers--;
                                return true;
                        }
                        break;
                    case Stats.Age_6_13 s6_13:
                        switch (Gender)
                        {
                            case "female":
                                s6_13.female--;
                                return true;

                            case "male":
                                s6_13.male--;
                                return true;

                            case "divers":
                                s6_13.divers--;
                                return true;
                        }
                        break;
                    case Stats.Age_18_Plus s18:
                        switch (Gender)
                        {
                            case "female":
                                s18.female--;
                                return true;

                            case "male":
                                s18.male--;
                                return true;

                            case "divers":
                                s18.divers--;
                                return true;
                        }
                        break;
                }

                return false;
            }

            if (G.CurrentStat.People.Contains(getID))
            {
                switch (AgeCategory)
                {
                    case "6-13":
                        if (update(G.CurrentStat.Age_6_13))
                        {
                            if (MigrationBackground) G.CurrentStat.Age_6_13.migration_background--;
                            return true;
                        }
                        break;
                    case "14-17":
                        if (update(G.CurrentStat.Age_14_17))
                        {
                            if (MigrationBackground) G.CurrentStat.Age_14_17.migration_background--;
                            return true;
                        }
                        break;

                    case "18+":
                        if (update(G.CurrentStat.Age_18_Plus))
                        {
                            if (MigrationBackground) G.CurrentStat.Age_18_Plus.migration_background--;
                            return true;
                        }
                        break;
                }
            }

            return false;
         }
        public bool AddStat()
        {
            if (G.CurrentStat == null)
            {
                G.CurrentStat = new Stat();
                G.CurrentStat.ID = G.LastStatID;
                ConsoleEx.WriteLine("Adding Default Stat. Date: " + G.CurrentStat.Date.ToString("d"));
                G.CurrentStat.Add();
            }

            bool update(object obj)
            {
                switch (obj)
                {
                    case Stats.Age_14_17 s14_17:
                        switch (Gender)
                        {
                            case "female":
                                s14_17.female++;
                                return true;

                            case "male":
                                s14_17.male++;
                                return true;

                            case "divers":
                                s14_17.divers++;
                                return true;
                        }
                        break;
                    case Stats.Age_6_13 s6_13:
                        switch (Gender)
                        {
                            case "female":
                                s6_13.female++;
                                return true;

                            case "male":
                                s6_13.male++;
                                return true;

                            case "divers":
                                s6_13.divers++;
                                return true;
                        }
                        break;
                    case Stats.Age_18_Plus s18:
                        switch (Gender)
                        {
                            case "female":
                                s18.female++;
                                return true;

                            case "male":
                                s18.male++;
                                return true;

                            case "divers":
                                s18.divers++;
                                return true;
                        }
                        break;
                }

                return false;
            }

            if (!G.CurrentStat.People.Contains(getID))
            {
                switch (AgeCategory)
                {
                    case "6-13":
                        if (update(G.CurrentStat.Age_6_13))
                        {
                            if (MigrationBackground) G.CurrentStat.Age_6_13.migration_background++;
                            return true;
                        }
                        break;
                    case "14-17":
                        if (update(G.CurrentStat.Age_14_17))
                        {
                            if (MigrationBackground) G.CurrentStat.Age_14_17.migration_background++;
                            return true;
                        }
                        break;

                    case "18+":
                        if (update(G.CurrentStat.Age_18_Plus))
                        {
                            if (MigrationBackground) G.CurrentStat.Age_18_Plus.migration_background++;
                            return true;
                        }
                        break;
                }
            }

            return false;
         }
        public void AddVisit(bool writeDB = true)
        {
            if (visitorItem == null)
            {
                visitorItem = new Custom_Controls.VisitorItem();
                visitorItem.person = this;
                visitorItem.Name_Label.Text = FirstName + " " + LastName;

                if (VisitTime == null)
                {
                    VisitTime = DateTime.Now.ToString("T");
                }

                visitorItem.Time_Label.Text = VisitTime;

                MyControls.TrackingTab.VisitorList.Controls.Add(visitorItem);
                SQL.AddVisit(this);

                if (AddStat())
                {
                    G.CurrentStat.People.Add(getID);
                    MyControls.Stats.RefreshStats(G.CurrentStat);

                    if (writeDB)
                    {
                        SQL.UpdateStat(G.CurrentStat);
                    }
                }             
            }
        }
        public void DeleteVisit()
        {
            if (visitorItem != null)
            {
                visitorItem.Dispose();
                visitorItem = null;
                VisitTime = null;

                SQL.DeleteVisit(this);

                if (DeleteStat())
                {
                    G.CurrentStat.People.Remove(getID);
                    MyControls.Stats.RefreshStats(G.CurrentStat);
                    SQL.UpdateStat(G.CurrentStat);
                }
            }
        }
        public void SaveQR()
        {
            MyQRCode.Save(this);
        }
        public void Add()
        {
            if (listItem == null)
            {
                Custom_Controls.PersonListItem item = new Custom_Controls.PersonListItem(MyControls.TrackingTab);
                listItem = item;

                item.person = this;
                item.UpdateValues();
                MyControls.TrackingTab.PersonList.Controls.Add(item);
            }

            if (!G.People.Contains(this))
            {
                G.People.Add(this);
            }
        }
        public void Save()
        {
            if (LastVisit == null)
            {
                LastVisit = DateTime.Now.ToString("d");
            }

            SQL.UpdateRow(this);
            RefreshCovid();
            Add();
        }
        public void LoadCard()
        {
            Custom_Controls.PersonCard pC = MyControls.Main.personCard;

            if (pC != null)
            {
                pC.temp = new Person();

                pC.FirstName_TextBox.Text = FirstName;
                pC.temp.FirstName = FirstName;

                pC.LastName_TextBox.Text = LastName;
                pC.temp.LastName = LastName;

                pC.Address_TextBox.Text = Address;
                pC.temp.Address = Address;

                pC.EMail_TextBox.Text = EMail;
                pC.temp.EMail = EMail;

                pC.Note_TextBox.Text = Note;
                pC.temp.Note = Note;

                pC.Phone_TextBox.Text = Phone;
                pC.temp.Phone = Phone;

                pC.PersonID.Text = Properties.strings.PersonalID + ": " + getID;
                pC.temp.ID = getID;

                pC.AgeCategory_Combo.SelectedItem = AgeCategory;
                pC.Migration_ChckBx.setChecked(MigrationBackground);
                pC.temp.MigrationBackground = MigrationBackground;

                pC.temp.Gender = Gender;
                pC.temp.DateOfBirth = DateOfBirth;
                pC.temp.Tested = Tested;
                pC.temp.Vaccinated = Vaccinated;

                DateTime date;

                if (DateTime.TryParse(DateOfBirth, out date)) pC.DateOfBirth_Picker.Value = date;

                if (DateTime.TryParse(Tested, out date)) pC.Tested_Picker.Value = date;

                if (DateTime.TryParse(Vaccinated, out date)) pC.Vaccinated_Picker.Value = date;

                if (Gender != null)
                {
                    switch (Gender)
                    {
                        case "male":
                            pC.GenderCombo.SelectedItem = Properties.strings.male;
                            break;
                        case "divers":
                            pC.GenderCombo.SelectedItem = Properties.strings.divers;
                            break;
                        case "female":
                            pC.GenderCombo.SelectedItem = Properties.strings.female;
                            break;
                    }
                }

                pC.QR_Code.Image = MyQRCode.Create(this);
            }
        }
        public void Delete()
        {
            if (listItem != null)
            {
                listItem.Dispose();
            }

            G.People.Remove(this);
            SQL.DeleteRow(this);
        }
        public void RefreshCovid()
        {
            if (listItem != null) {
                if (validCovid() == false)
                {
                    listItem.setFailed();
                }
                else
                {
                    listItem.setPassed();
                }
            }
        }
        public bool validCovid()
        {
            DateTime date;

            if (DateTime.TryParse(DateOfBirth, out date)) 
            {
                if (G.Years(date, DateTime.Now) < Properties.Settings.Default.Corona_MinAgeTest)
                {
                    //ConsoleEx.WriteLine("Young enough! Only " + G.Years(date, DateTime.Now) + " years!");
                    return true;
                }
            }

            if (DateTime.TryParse(Tested, out date)) 
            {
                if (DateTime.Now.Subtract(date).TotalHours < Properties.Settings.Default.Corona_TestedDuration)
                {
                    // ConsoleEx.WriteLine("Last Test less than 48 hours! Only " + DateTime.Now.Subtract(date).TotalHours + " hours passed!");
                    return true;
                }                
            }

            if (DateTime.TryParse(Vaccinated, out date)) 
            {
                if (DateTime.Now.Subtract(date).TotalDays < Properties.Settings.Default.Corona_VaccinatedDuration)
                {
                    // ConsoleEx.WriteLine("Vaccinated less than 90 days ago! Only " + DateTime.Now.Subtract(date).TotalDays + " days passed!");
                    return true;
                }
            }

            return false;
        }
    }
}
