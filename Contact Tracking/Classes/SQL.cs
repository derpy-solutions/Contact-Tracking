using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace Contact_Tracking
{
    public class SQL
    {
        public static string statSplit;
        public static string _statSplit;

        public static bool logSplit;
        public static bool _logSplit;

        public bool open_db;
        public static bool busy;
        public static void Run()
        {
            ConsoleEx.WriteLine("Setup Database");
           if  (CreateTable())
            {
                Random rnd = new Random();

                List<Person> defaults = new List<Person>();
                defaults.Add(new Person()
                {
                    FirstName = "Albus",
                    LastName = "Dumbledore",
                    MigrationBackground = false,
                    LastVisit = DateTime.Now.AddDays(0).ToString("d"),
                    Vaccinated = DateTime.Now.AddDays(-37).ToString("d"),
                    ID = defaults.Count + 1,
                    DateOfBirth = rnd.Next(1, 28) + "." + rnd.Next(1, 12) + "." + rnd.Next(1990, 2010),
                    Gender = "male",
                    Address = "My Fancy Street No." + rnd.Next(1, 150),
                    Phone = "0" + rnd.Next(10000000, 99999999).ToString(),
                    EMail = "albus@dumbledore.com",
                });
                defaults.Add(new Person()
                {
                    FirstName = "Severus",
                    LastName = "Snape",
                    LastVisit = DateTime.Now.ToString("d"),
                    MigrationBackground = false,
                    Gender = "male",
                    ID = defaults.Count + 1,
                    DateOfBirth = rnd.Next(1, 28) + "." + rnd.Next(1, 12) + "." + rnd.Next(1990, 2010),
                    Address = "My Fancy Street No." + rnd.Next(1, 150),
                    Phone = "0" + rnd.Next(10000000, 99999999).ToString(),
                    EMail = "severus@snape.com",
                });
                defaults.Add(new Person()
                {
                    FirstName = "Harry",
                    LastName = "Potter",
                    Vaccinated = DateTime.Now.AddDays(-45).ToString("d"),
                    MigrationBackground = false,
                    Gender = "male",
                    Tested = DateTime.Now.AddHours(-27).ToString("g"),
                    LastVisit = DateTime.Now.ToString("d"),
                    ID = defaults.Count + 1,
                    DateOfBirth = rnd.Next(1, 28) + "." + rnd.Next(1, 12) + "." + rnd.Next(1990, 2010),
                    Address = "My Fancy Street No." + rnd.Next(1, 150),
                    Phone = "0" + rnd.Next(10000000, 99999999).ToString(),
                    EMail = "harry@potter.com",
                });
                defaults.Add(new Person()
                {
                    FirstName = "Hermine",
                    LastName = "Granger",
                    MigrationBackground = true,
                    Gender = "female",
                    LastVisit = DateTime.Now.ToString("d"),
                    Vaccinated = DateTime.Now.AddDays(-28).ToString("d"),
                    ID = defaults.Count + 1,
                    DateOfBirth = "04.10.2007",
                    Address = "My Fancy Street No." + rnd.Next(1, 150),
                    Phone = "0" + rnd.Next(10000000, 99999999).ToString(),
                    EMail = "hermine@granger.com",
                });
                defaults.Add(new Person()
                {
                    FirstName = "Ron",
                    LastName = "Weasley",
                    MigrationBackground = true,
                    Gender = "male",
                    Tested = DateTime.Now.AddHours(-14).ToString("g"),
                    LastVisit = DateTime.Now.ToString("d"),
                    ID = defaults.Count + 1,
                    DateOfBirth = rnd.Next(1, 28) + "." + rnd.Next(1, 12) + "." + rnd.Next(1990, 2010),
                    Address = "My Fancy Street No." + rnd.Next(1, 150),
                    Phone = "0" + rnd.Next(10000000, 99999999).ToString(),
                    EMail = "ron@weasley.com",
                });

                foreach (Person person in defaults)
                {
                    AddRow(person);
                }
            }
            CreateLogsTable();

            if (CreateStatsTable())
            {
                Random rnd = new Random();

                for (int i = 1; i < 30; i ++)
                {
                    Stat stat = new Stat();
                    stat.ID = i;
                    ConsoleEx.WriteLine("Set Date from Sample Stats");
                    stat.Date = DateTime.FromOADate(DateTime.Now.AddDays(i - 1).ToOADate());
                    stat.Age_6_13.female = rnd.Next(0, 15);
                    stat.Age_6_13.male = rnd.Next(0, 15);
                    stat.Age_6_13.divers = rnd.Next(0, 5);
                    var total = (stat.Age_6_13.female + stat.Age_6_13.male + stat.Age_6_13.divers);
                    stat.Age_6_13.migration_background = rnd.Next(Convert.ToInt32(total*0.25), total);

                    stat.Age_14_17.female = rnd.Next(0, 15);
                    stat.Age_14_17.male = rnd.Next(0, 15);
                    stat.Age_14_17.divers = rnd.Next(0, 5);
                    var total2 = (stat.Age_14_17.female + stat.Age_14_17.male + stat.Age_14_17.divers);
                    stat.Age_14_17.migration_background = rnd.Next(Convert.ToInt32(total2*0.25), total2);

                    stat.Age_18_Plus.female = rnd.Next(0, 15);
                    stat.Age_18_Plus.male = rnd.Next(0, 15);
                    stat.Age_18_Plus.divers = rnd.Next(0, 5);
                    var total3 = (stat.Age_18_Plus.female + stat.Age_18_Plus.male + stat.Age_18_Plus.divers);
                    stat.Age_18_Plus.migration_background = rnd.Next(Convert.ToInt32(total3*0.25), total3);

                    stat.Add();
                }
            }

            ClearLogs();

            ReadTable();
            ReadStats();
            ReadLog();

            if (G.CurrentStat == null )
            {
                G.LastStatID++;

                G.CurrentStat = new Stat();
                ConsoleEx.WriteLine("Adding Default Stat in SQL Load. Date: " + G.CurrentStat.Date.ToString("d") + " with ID: "+ G.LastStatID);

                G.CurrentStat.ID = G.LastStatID;
            }

            string lastLogName = LogName();
            MyControls.TrackingTab.Log_Label.Text = "Log No. " + lastLogName[lastLogName.Length - 1]; ;
        }
        public static string LogName()
        {
            string log_num = "1";

         if (Properties.Settings.Default.SplitLog)
            {
                DateTime dateTime = DateTime.Parse(DateTime.Now.ToString("d") + " " + Properties.Settings.Default.SplitLogAt);

                if (DateTime.Now >= dateTime)
                {
                    log_num = "2";
                }
             }

            return DateTime.Now.ToString("d") + " Log " + "No. " + log_num;
        }
        public static string StatsName()
        {
            string log_num = "1";
            
            if (Properties.Settings.Default.SplitStats)
            {
                DateTime dateTime = DateTime.Parse(DateTime.Now.ToString("d") + " " + Properties.Settings.Default.SplitStatsAt);

                if (DateTime.Now >= dateTime)
                {
                    log_num = "2";
                }
            }

            return DateTime.Now.ToString("d") + " Log " + "No. " + log_num;
        }
        public static int StatsID()
        {
            return G.LastStatID;
        }
        public static bool EntryExists(SQLiteConnection connection, int ID, string tbl = "Person")
        {
            SQLiteCommand existing = new SQLiteCommand($"SELECT count(*) FROM '" + tbl + $"' WHERE ID='{ID}'", connection);
            int count = Convert.ToInt32(existing.ExecuteScalar());
            return count > 0;
        }
        public static bool TableExists(String tableName, SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "SELECT COUNT(*) AS QtRecords FROM sqlite_master WHERE type = 'table' AND name = @name";
                cmd.Parameters.AddWithValue("@name", tableName);
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    return false;
                else
                    return true;
            }
        }
        public static bool CreateTable()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();           

            if (!TableExists("Person", connection))
            {
                ConsoleEx.WriteLine("Create Person Table.");

                string core = "FirstName text, LastName text, DateOfBirth text, Address text, Phone text, EMail text, Note text";
                string statistics = "MigrationBackground text, Gender text, AgeCategory text";
                string covid = "Tested text, Vaccinated text";

                string tbl = "create table Person (ID integer primary key autoincrement, LastVisit text, " + core + ", " + statistics + ", " + covid +  ")";
                SQLiteCommand command = new SQLiteCommand(tbl, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
        public static bool CreateStatsTable()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();           

            if (!TableExists("Statistic", connection))
            {
                ConsoleEx.WriteLine("Stats Table.");
                string Age_18_Plus = "Age_18_Plus_divers integer, Age_18_Plus_male integer, Age_18_Plus_female integer, Age_18_Plus_migration_background integer";
                string Age_14_17 = "Age_14_17_divers integer, Age_14_17_male integer, Age_14_17_female integer, Age_14_17_migration_background integer";
                string Age_6_13 = "Age_6_13_divers integer, Age_6_13_male integer, Age_6_13_female integer, Age_6_13_migration_background integer";
                string tbl = "create table '" + "Statistic" + "' (ID integer primary key autoincrement, Name text, Date text, People text, "+ Age_6_13+ ", " + Age_14_17 + ", "+ Age_18_Plus +" )";
                SQLiteCommand command = new SQLiteCommand(tbl, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
        public static void ReadStats()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            using (SQLiteConnection connection = new SQLiteConnection(dbfile))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand("select * from Statistic", connection);
                SQLiteDataReader reader = cmd.ExecuteReader();
                List<int> wipeIDs = new List<int>();

                ConsoleEx.WriteLine("Read Stats ...");
                while (reader.Read())
                {
                    Stat stat = new Stat();
                    ConsoleEx.WriteLine("Read Stat ID: " + int.Parse(reader["ID"].ToString()));

                    stat.ID = int.Parse(reader["ID"].ToString());
                    stat._Name = reader["Name"].ToString();
                    stat.Date = DateTime.Parse(reader["Date"].ToString());

                    if (DateTime.Now.Subtract(stat.Date).TotalDays < Properties.Settings.Default.Stats_DaysToSave)
                    {
                        stat.Age_6_13.divers = int.Parse(reader["Age_6_13_divers"].ToString());
                        stat.Age_6_13.male = int.Parse(reader["Age_6_13_male"].ToString());
                        stat.Age_6_13.female = int.Parse(reader["Age_6_13_female"].ToString());
                        stat.Age_6_13.migration_background = int.Parse(reader["Age_6_13_migration_background"].ToString());

                        stat.Age_14_17.divers = int.Parse(reader["Age_14_17_divers"].ToString());
                        stat.Age_14_17.male = int.Parse(reader["Age_14_17_male"].ToString());
                        stat.Age_14_17.female = int.Parse(reader["Age_14_17_female"].ToString());
                        stat.Age_14_17.migration_background = int.Parse(reader["Age_14_17_migration_background"].ToString());

                        stat.Age_18_Plus.divers = int.Parse(reader["Age_18_Plus_divers"].ToString());
                        stat.Age_18_Plus.male = int.Parse(reader["Age_18_Plus_male"].ToString());
                        stat.Age_18_Plus.female = int.Parse(reader["Age_18_Plus_female"].ToString());
                        stat.Age_18_Plus.migration_background = int.Parse(reader["Age_18_Plus_migration_background"].ToString());

                        string ids = reader["People"].ToString();

                        string[] subs = ids.Split('|');

                        foreach (var sub in subs)
                        {
                            stat.People.Add(int.Parse(sub));
                        }

                        stat.Add(false);

                        if (stat.Name == StatsName())
                        {
                            ConsoleEx.WriteLine("Found Current Stat. Set to Current. ID: " + stat.ID);
                            G.CurrentStat = stat;
                        }
                    } 
                    else
                    {
                        wipeIDs.Add(stat.ID);
                    }
                }
                ConsoleEx.WriteLine("Stats Read!");

                foreach (int id in wipeIDs)
                {
                    ConsoleEx.WriteLine("Delete Statistic with ID: " + id);
                    string deleteperson = $"delete from Statistic where id={id};";
                    SQLiteCommand command = new SQLiteCommand(deleteperson, connection);
                    command.ExecuteNonQuery();
                }
            }

            for (int i = G.Stats.Count -1; i > 0; i--)
            {
                if (MyControls.Stats.Controls.Count <= Properties.Settings.Default.Stats_DaysToShow)
                {
                    G.Stats[i].AddEntry();
                }
                else
                {
                    break;
                }
            }
        }
        public static void WipePeople()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            using (SQLiteConnection connection = new SQLiteConnection(dbfile))
            {
                connection.Open();

                foreach (Person p in G.People)
                {
                    SQLiteCommand cmd = new SQLiteCommand($"delete from Person where ID={p.ID};", connection);
                    cmd.ExecuteNonQuery();
                    if (p.listItem != null) {
                        p.listItem.Dispose();
                    }                    
                }

                G.People.Clear();
                connection.Close();
            }
        }

        public static void WipeStats()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            using (SQLiteConnection connection = new SQLiteConnection(dbfile))
            {
                connection.Open();

                foreach (Stat stat in G.Stats)
                {
                    SQLiteCommand cmd = new SQLiteCommand($"delete from Statistic where ID={stat.ID};", connection);
                    cmd.ExecuteNonQuery();
                }

                G.Stats.Clear();
                connection.Close();
            }
        }
        public static void UpdateStat(Stat s)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();

            if (EntryExists(connection, s.ID, "Statistic"))
            {
                string Age_6_13 = $"Age_6_13_divers='{s.Age_6_13.divers}', Age_6_13_male='{s.Age_6_13.male}', Age_6_13_female='{s.Age_6_13.female}', Age_6_13_migration_background='{s.Age_6_13.migration_background}'";
                string Age_14_17 = $"Age_14_17_divers='{s.Age_14_17.divers}', Age_14_17_male='{s.Age_14_17.male}', Age_14_17_female='{s.Age_14_17.female}', Age_14_17_migration_background='{s.Age_14_17.migration_background}'";
                string Age_18_Plus = $"Age_18_Plus_divers='{s.Age_18_Plus.divers}', Age_18_Plus_male='{s.Age_18_Plus.male}', Age_18_Plus_female='{s.Age_18_Plus.female}', Age_18_Plus_migration_background='{s.Age_18_Plus.migration_background}'";
                string people = string.Join("|", s.People);
                string updatestat= $"update Statistic set Name='{s.Name}', Date='{s.Date}', People='{people}', " + Age_6_13 + ", " + Age_14_17   + ", " + Age_18_Plus + $" where id={s.ID};";
                SQLiteCommand command = new SQLiteCommand(updatestat, connection);
                command.ExecuteNonQuery();
            }
            else
            {
                G.LastStatID = Math.Max(StatsID(), G.LastStatID);
                string Age_18_Plus = "Age_18_Plus_divers, Age_18_Plus_male, Age_18_Plus_female, Age_18_Plus_migration_background";
                string Age_14_17 = "Age_14_17_divers, Age_14_17_male, Age_14_17_female, Age_14_17_migration_background";
                string Age_6_13 = "Age_6_13_divers, Age_6_13_male, Age_6_13_female, Age_6_13_migration_background";
                string people = string.Join("|", s.People);


                string Age_6_13_values = $"'{s.Age_6_13.divers}', '{s.Age_6_13.male}', '{s.Age_6_13.female}','{s.Age_6_13.migration_background}'";
                string Age_14_17_values = $"'{s.Age_14_17.divers}', '{s.Age_14_17.male}', '{s.Age_14_17.female}','{s.Age_14_17.migration_background}'";
                string Age_18_Plus_values = $"'{s.Age_18_Plus.divers}', '{s.Age_18_Plus.male}', '{s.Age_18_Plus.female}','{s.Age_18_Plus.migration_background}'";
                string addstat = $"insert into Statistic (ID, Name, Date, People, " + Age_6_13 + ", " + Age_14_17 + ", " + Age_18_Plus + $") values ({s.ID}, '{s.Name}', '{s.Date}', '{people}', " + Age_6_13_values+ ", " + Age_14_17_values + ", " + Age_18_Plus_values + ");";
                SQLiteCommand command = new SQLiteCommand(addstat, connection);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
        public static bool CreateLogsTable()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();           

            if (!TableExists(LogName(), connection))
            {
                ConsoleEx.WriteLine("Create Log Table.");
                string tbl = "create table '" + LogName() + "' (ID integer primary key, Date text, Time text, FirstName text, LastName text, DateOfBirth text, Address text, Phone text, EMail text)";
                SQLiteCommand command = new SQLiteCommand(tbl, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
        public static List<string> GetTables()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";

            List<string> tables = new List<string>();
            using (SQLiteConnection con = new SQLiteConnection(dbfile))
            {
                con.Open();
                DataTable dt = con.GetSchema("Tables");
                foreach (DataRow row in dt.Rows)
                {
                    string tablename = (string)row[2];
                    tables.Add(tablename);
                }
                con.Close();
            }
            return tables;
        }

        public static void AddVisit(Person p)
        {
                if (Properties.Settings.Default.SaveVisits)
            {
                string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
                SQLiteConnection connection = new SQLiteConnection(dbfile);
                connection.Open();

                if (!TableExists(LogName(), connection))
                {
                    string tbl = "create table '" + LogName() + "' (ID integer primary key, Date text, Time text, FirstName text, LastName text, DateOfBirth text, Address text, Phone text, EMail text)";
                    SQLiteCommand command = new SQLiteCommand(tbl, connection);
                    command.ExecuteNonQuery();
                }

                if (!EntryExists(connection, p.ID, LogName()))
                {
                    G.LastID = Math.Max(p.getID, G.LastID);
                    string addperson = $"insert into '" + LogName() + $"' (ID, Date, Time, FirstName, LastName, DateOfBirth, Address, Phone, EMail) values ({p.getID}, '{DateTime.Now.ToString("d")}', '{p.VisitTime}', '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}');";
                    SQLiteCommand command = new SQLiteCommand(addperson, connection);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
        public static void DeleteVisit(Person p)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            if (EntryExists(connection, p.ID, LogName()))
            {
                string deleteperson = $"delete from '" + LogName() + $"' where id={p.getID};";
                SQLiteCommand command = new SQLiteCommand(deleteperson, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public static void ReadLog()
        {
            if (Properties.Settings.Default.SaveVisits)
            {
                string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
                using (SQLiteConnection connection = new SQLiteConnection(dbfile))
                {
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("select * from '" + LogName() + "'", connection);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    List<int> wipeIDs = new List<int>();

                    ConsoleEx.WriteLine("Read Logs ...");
                    while (reader.Read())
                    {
                        Person p = new Person();
                        p.ID = int.Parse(reader["ID"].ToString());
                        p.VisitTime = reader["Time"].ToString();
                        p.FirstName = Encryption.Decrypt(reader["FirstName"].ToString());
                        p.LastName = Encryption.Decrypt(reader["LastName"].ToString());
                        p.DateOfBirth = Encryption.Decrypt(reader["DateOfBirth"].ToString());
                        p.Address = Encryption.Decrypt(reader["Address"].ToString());
                        p.Phone = Encryption.Decrypt(reader["Phone"].ToString());
                        p.EMail = Encryption.Decrypt(reader["EMail"].ToString());
                        bool found = false;
                        foreach (Person person in G.People)
                        {
                            if (person.EqualsPerson(p))
                            {
                                person.VisitTime = p.VisitTime;
                                person.AddVisit(false);
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            p.Add();
                            p.AddVisit(false);
                        }
                    }

                    ConsoleEx.WriteLine("Logs Read!");
                }
            }
        }
        public static void WipeLogs()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            List<string> names = GetTables();

            if (names.Count > 0)
            {
                using (SQLiteConnection connection = new SQLiteConnection(dbfile))
                {
                    connection.Open();

                    foreach (string name in names)
                    {
                        if (name != "Person" && name != "sqlite_sequence" && name != "Statistic")
                        {
                            SQLiteCommand command = new SQLiteCommand("DROP TABLE '" + name + "'", connection);
                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }
            }

            CreateLogsTable();

            foreach (Person p in G.People)
            {
                if (p.visitorItem != null)
                {
                    p.visitorItem.Dispose();
                    p.visitorItem = null;
                    p.VisitTime = null;
                }
            }
        }
        public static void ClearLogs()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            List<string> names = GetTables();

            if (names.Count > 0)
            {
                using (SQLiteConnection connection = new SQLiteConnection(dbfile))
                {
                    connection.Open();
                    ConsoleEx.WriteLine("ClearLogs ...");

                    foreach (string name in names)
                    {
                        if (name != "Person" && name != "sqlite_sequence" && name != "Statistic")
                        {
                            SQLiteCommand command = new SQLiteCommand("select Date from '" + name + "'", connection);
                            SQLiteDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                string logDate = reader["Date"].ToString();

                                DateTime date;
                                if (DateTime.TryParse(logDate, out date))
                                {
                                    if (DateTime.Now.Subtract(date).TotalDays >= Properties.Settings.Default.VisitDaysSave)
                                    {
                                        ConsoleEx.WriteLine("Wipe Log " + name  + " since its already " + DateTime.Now.Subtract(date).TotalDays  + " days old!");
                                        SQLiteCommand cmd = new SQLiteCommand("DROP TABLE '" + name + "'", connection);
                                        cmd.ExecuteNonQuery();
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
            }
        }
        public static void AddRow(Person p)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            if (!EntryExists(connection, p.ID))
            {
                G.LastID = Math.Max(p.getID, G.LastID);
                string core = "FirstName, LastName, DateOfBirth, Address, Phone, EMail, Note";
                string coreValues = $" '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}', '{Encryption.Encrypt(p.Note)}'";

                string statistics = "MigrationBackground, Gender, AgeCategory";
                string statisticsValues = $" '{Encryption.Encrypt(p.MigrationBackground.ToString())}', '{Encryption.Encrypt(p.Gender)}',  '{Encryption.Encrypt(p.AgeCategory)}'";

                string covid = "Tested, Vaccinated";
                string covidValues = $"'{Encryption.Encrypt(p.Tested)}', '{Encryption.Encrypt(p.Vaccinated)}'";

                string addperson = $"insert into Person (ID, LastVisit, " + core + ", " + statistics + ", " + covid + $") values ({p.getID}, '{Encryption.Encrypt(p.LastVisit)}', " + coreValues + ", " + statisticsValues + ", " + covidValues + ");";
                ConsoleEx.WriteLine(addperson);
                SQLiteCommand command = new SQLiteCommand(addperson, connection);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
        public static void DeleteRow(Person p)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            if (EntryExists(connection, p.ID))
            {
                ConsoleEx.WriteLine("Delete DB Row with ID: " + p.getID);
                string deleteperson = $"delete from Person where id={p.getID};";
                SQLiteCommand command = new SQLiteCommand(deleteperson, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public static void UpdateRow(Person p)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            
            if (EntryExists(connection, p.ID))
            {
                string core = $"FirstName='{Encryption.Encrypt(p.FirstName)}', LastName='{Encryption.Encrypt(p.LastName)}', DateOfBirth='{Encryption.Encrypt(p.DateOfBirth)}', Address='{Encryption.Encrypt(p.Address)}', Phone='{Encryption.Encrypt(p.Phone)}', EMail='{Encryption.Encrypt(p.EMail)}', Note='{Encryption.Encrypt(p.Note)}'";
                string statistics = $"MigrationBackground='{Encryption.Encrypt(p.MigrationBackground.ToString())}', Gender='{Encryption.Encrypt(p.Gender)}', AgeCategory='{Encryption.Encrypt(p.AgeCategory)}'";
                string covid = $"Tested='{Encryption.Encrypt(p.Tested)}', Vaccinated='{Encryption.Encrypt(p.Vaccinated)}'";

                string updateperson = $"update Person set " + core + ", " + statistics + ", " + covid + $" where id={p.getID};";
                SQLiteCommand command = new SQLiteCommand(updateperson, connection);
                command.ExecuteNonQuery();
            }
            else
            {
                G.LastID = Math.Max(p.getID, G.LastID);
                string core = "FirstName, LastName, DateOfBirth, Address, Phone, EMail, Note";
                string coreValues = $" '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}', '{Encryption.Encrypt(p.Note)}'";

                string statistics = "MigrationBackground, Gender, AgeCategory";
                string statisticsValues = $" '{Encryption.Encrypt(p.MigrationBackground.ToString())}', '{Encryption.Encrypt(p.Gender)}',  '{Encryption.Encrypt(p.AgeCategory)}'";

                string covid = "Tested, Vaccinated";
                string covidValues = $"'{Encryption.Encrypt(p.Tested)}', '{Encryption.Encrypt(p.Vaccinated)}'";

                string addperson = $"insert into Person (ID, LastVisit, " + core  + ", " + statistics + ", " + covid + $") values ({p.getID}, '{Encryption.Encrypt(p.LastVisit)}', " + coreValues + ", " + statisticsValues + ", " + covidValues + ");";
                SQLiteCommand command = new SQLiteCommand(addperson, connection);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
        public static void ReadTable()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            using (SQLiteConnection connection = new SQLiteConnection(dbfile))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand("select * from Person", connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                bool indexExists(string columnName, SQLiteDataReader dr)
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {

                        if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                            return true;
                    }
                    return false;
                }

                string readFromReader(string index, SQLiteDataReader dr, bool encrypted = true)
                {
                    if (indexExists(index, dr))
                    {
                        if (encrypted) 
                        {
                            return Encryption.Decrypt(reader[index].ToString());
                        }
                        else
                        {
                            return reader[index].ToString();
                        }
                    }

                    return null;
                }
                List<int> wipeIDs = new List<int>();

                ConsoleEx.WriteLine("Read People ...");
                while (reader.Read()) 
                {
                    bool added = false;
                    string lastVisit = readFromReader("LastVisit", reader);

                    if (lastVisit != null && lastVisit != "")
                    {
                        DateTime date;
                        if (DateTime.TryParse(lastVisit, out date))
                        {
                            if (DateTime.Now.Subtract(date).TotalDays < Properties.Settings.Default.PersonIdleDays)
                            {
                                Person p = new Person();
                                p.ID = int.Parse(readFromReader("ID", reader, false));
                                p.FirstName = readFromReader("FirstName", reader);
                                p.LastName = readFromReader("LastName", reader);
                                p.MigrationBackground = bool.Parse(readFromReader("MigrationBackground", reader));
                                p.Gender = readFromReader("Gender", reader);
                                p.AgeCategory = readFromReader("AgeCategory", reader);
                                p.DateOfBirth = readFromReader("DateOfBirth", reader);
                                p.Address = readFromReader("Address", reader);
                                p.Phone = readFromReader("Phone", reader);
                                p.EMail = readFromReader("EMail", reader);
                                p.Note = readFromReader("Note", reader);
                                p.Tested = readFromReader("Tested", reader);
                                p.Vaccinated = readFromReader("Vaccinated", reader);
                                p.LastVisit = readFromReader("LastVisit", reader);
                                added = true;
                                p.Add();
                            }
                        }
                    }

                    if (!added)
                    {
                        wipeIDs.Add(int.Parse(readFromReader("ID", reader, false)));
                    }
                }

                ConsoleEx.WriteLine("People Read!");

                if (TableExists("sqlite_sequence", connection)) { 
                    SQLiteCommand cmd2 = new SQLiteCommand("select * from sqlite_sequence", connection);
                    SQLiteDataReader reader2 = cmd2.ExecuteReader();
                    ConsoleEx.WriteLine("Read Increments ...");
                    while (reader2.Read())
                    {
                        if (reader2["name"].ToString() == "Person")
                    {
                        G.LastID = int.Parse(reader2["seq"].ToString());
                            ConsoleEx.WriteLine("Last assigned ID: " + G.LastID);
                        }

                    if (reader2["name"].ToString() == "Statistic")
                    {
                        G.LastStatID = int.Parse(reader2["seq"].ToString());
                            ConsoleEx.WriteLine("Last assigned Stat ID: " + G.LastStatID);
                        }
                    }
                    ConsoleEx.WriteLine("Increments Read!");
                }

                foreach(int id in wipeIDs)
                {
                    ConsoleEx.WriteLine("Delete Person with ID: " + id);
                    string deleteperson = $"delete from Person where id={id};";
                    SQLiteCommand command = new SQLiteCommand(deleteperson, connection);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
