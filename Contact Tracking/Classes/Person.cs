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
        public string Sex;
        public bool MigrationBackground;
        public string DateOfBirth;
        public string Address;
        public string Phone;
        public string EMail;
        public string Note;
        public string Tested;
        public string Vaccinated;
        public string VisitTime;
        public string Created;
        public bool statAdded = false;
        public bool _statAdded = false;
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
                return $"{ID}|{FirstName}|{LastName}|{Sex}|{DateOfBirth}|{Address}|{Phone}|{EMail}";
            }
        }
        public string FileName {
            get
            {
                return $"{FirstName} {LastName} - {DateOfBirth}";
            }
        }
        public void AddVisit()
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

                if (G.CurrentStat == null)
                {
                    G.CurrentStat = new Stat();
                    G.CurrentStat.ID = G.LastStatID;
                    G.CurrentStat.Date = DateTime.Now;
                    G.CurrentStat.Add();
                }


                DateTime date;
                if (DateTime.TryParse(DateOfBirth, out date))
                {
                    switch (G.Years(date, DateTime.Now))
                    {
                        case int n when (n <= 12):
                            //12 or younger
                            switch (Sex)
                            {
                                case "female":
                                    statAdded = true;
                                    G.CurrentStat.Age_6_12.female++;
                                    if (MigrationBackground) G.CurrentStat.Age_6_12.migration_background++;
                                    break;
                                case "male":
                                    statAdded = true;
                                    G.CurrentStat.Age_6_12.male++;
                                    if (MigrationBackground) G.CurrentStat.Age_6_12.migration_background++;
                                    break;
                                case "divers":
                                    statAdded = true;
                                    G.CurrentStat.Age_6_12.divers++;
                                    if (MigrationBackground) G.CurrentStat.Age_6_12.migration_background++;
                                    break;
                            }
                                
                        break;

                        case int n when (n <= 17):
                            //17 or younger
                            switch (Sex)
                            {
                                case "female":
                                    statAdded = true;
                                    G.CurrentStat.Age_13_17.female++;
                                    if (MigrationBackground) G.CurrentStat.Age_13_17.migration_background++;
                                    break;
                                case "male":
                                    statAdded = true;
                                    G.CurrentStat.Age_13_17.male++;
                                    if (MigrationBackground) G.CurrentStat.Age_13_17.migration_background++;
                                    break;
                                case "divers":
                                    statAdded = true;
                                    G.CurrentStat.Age_13_17.divers++;
                                    if (MigrationBackground) G.CurrentStat.Age_13_17.migration_background++;
                                    break;
                            }
                            break;

                        case int n when (n >= 18):
                            //18 or older
                            switch (Sex)
                            {
                                case "female":
                                    statAdded = true;
                                    G.CurrentStat.Age_18_27.female++;
                                    if (MigrationBackground) G.CurrentStat.Age_18_27.migration_background++;
                                    break;
                                case "male":
                                    statAdded = true;
                                    G.CurrentStat.Age_18_27.male++;
                                    if (MigrationBackground) G.CurrentStat.Age_18_27.migration_background++;
                                    break;
                                case "divers":
                                    statAdded = true;
                                    G.CurrentStat.Age_18_27.divers++;
                                    if (MigrationBackground) G.CurrentStat.Age_18_27.migration_background++;
                                    break;
                            }
                            break;
                    }
                }

                if (statAdded && statAdded != _statAdded)
                {
                    Console.WriteLine("Added " + FullName + " to our stats.");
                    _statAdded = statAdded;
                    SQL.UpdateStat(G.CurrentStat);
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

                if (statAdded)
                {
                    DateTime date;
                    if (DateTime.TryParse(DateOfBirth, out date))
                    {
                        switch (G.Years(date, DateTime.Now))
                        {
                            case int n when (n <= 12):
                                //12 or younger
                                switch (Sex)
                                {
                                    case "female":
                                        statAdded = false;
                                        G.CurrentStat.Age_6_12.female--;
                                        if (MigrationBackground) G.CurrentStat.Age_6_12.migration_background--;
                                        break;
                                    case "male":
                                        statAdded = false;
                                        G.CurrentStat.Age_6_12.male--;
                                        if (MigrationBackground) G.CurrentStat.Age_6_12.migration_background--;
                                        break;
                                    case "divers":
                                        statAdded = false;
                                        G.CurrentStat.Age_6_12.divers--;
                                        if (MigrationBackground) G.CurrentStat.Age_6_12.migration_background--;
                                        break;
                                }

                                break;

                            case int n when (n <= 17):
                                //17 or younger
                                switch (Sex)
                                {
                                    case "female":
                                        statAdded = false;
                                        G.CurrentStat.Age_13_17.female--;
                                        if (MigrationBackground) G.CurrentStat.Age_13_17.migration_background--;
                                        break;

                                    case "male":
                                        statAdded = false;
                                        G.CurrentStat.Age_13_17.male--;
                                        if (MigrationBackground) G.CurrentStat.Age_13_17.migration_background--;
                                        break;

                                    case "divers":
                                        statAdded = false;
                                        G.CurrentStat.Age_13_17.divers--;
                                        if (MigrationBackground) G.CurrentStat.Age_13_17.migration_background--;
                                        break;
                                }
                                break;

                            case int n when (n >= 18):
                                //18 or older
                                switch (Sex)
                                {
                                    case "female":
                                        statAdded = false;
                                        G.CurrentStat.Age_18_27.female--;
                                        if (MigrationBackground) G.CurrentStat.Age_18_27.migration_background--;
                                        break;
                                    case "male":
                                        statAdded = false;
                                        G.CurrentStat.Age_18_27.male--;
                                        if (MigrationBackground) G.CurrentStat.Age_18_27.migration_background--;
                                        break;
                                    case "divers":
                                        statAdded = false;
                                        G.CurrentStat.Age_18_27.divers--;
                                        if (MigrationBackground) G.CurrentStat.Age_18_27.migration_background--;
                                        break;
                                }
                                break;
                        }
                    }

                    if (!statAdded && _statAdded != statAdded)
                    {
                        Console.WriteLine("Removed " + FullName + " from our stats.");
                        _statAdded = statAdded;
                        SQL.UpdateStat(G.CurrentStat);
                    }
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

                pC.PersonID.Text = "Persönliche ID: " + getID;
                pC.temp.ID = getID;

                pC.temp.Sex = Sex;
                pC.temp.DateOfBirth = DateOfBirth;
                pC.temp.Tested = Tested;
                pC.temp.Vaccinated = Vaccinated;

                DateTime date;

                if (DateTime.TryParse(DateOfBirth, out date)) pC.DateOfBirth_Picker.Value = date;
                else pC.DateOfBirth_Picker.Value = DateTime.Now;

                if (DateTime.TryParse(Tested, out date)) pC.Tested_Picker.Value = date;
                else pC.Tested_Picker.Value = DateTime.Now;

                if (DateTime.TryParse(Vaccinated, out date)) pC.Vaccinated_Picker.Value = date;
                else pC.Vaccinated_Picker.Value = DateTime.Now;

                if (Sex != null)
                {
                    switch (Sex)
                    {
                        case "male":
                            pC.SexCombo.SelectedItem = "männlich";
                            break;
                        case "divers":
                            pC.SexCombo.SelectedItem = "divers";
                            break;
                        case "female":
                            pC.SexCombo.SelectedItem = "weiblich";
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
                if (G.Years(date, DateTime.Now) < 13)
                {
                    Console.WriteLine("Young enough! Only " + G.Years(date, DateTime.Now) + " years!");
                    return true;
                }
            }

            if (DateTime.TryParse(Tested, out date)) 
            {
                if (DateTime.Now.Subtract(date).TotalHours < 48)
                {
                    Console.WriteLine("Last Test less than 48 hours! Only " + DateTime.Now.Subtract(date).TotalHours + " hours passed!");
                    return true;
                }                
            }

            if (DateTime.TryParse(Vaccinated, out date)) 
            {
                if (DateTime.Now.Subtract(date).TotalDays < 90)
                {
                    Console.WriteLine("Vaccinated less than 90 days ago! Only " + DateTime.Now.Subtract(date).TotalDays + " days passed!");
                    return true;
                }
            }

            return false;
        }
    }
}
