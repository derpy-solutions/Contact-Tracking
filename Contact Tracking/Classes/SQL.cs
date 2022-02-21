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
        public static void Run()
        {
            Console.WriteLine("Setup Database");
           if  (CreateTable())
            {
                Random rnd = new Random();

                List<Person> defaults = new List<Person>();
                defaults.Add(new Person()
                {
                    FirstName = "Albus",
                    LastName = "Dumbledore",
                    MigrationBackground = false,
                    Created = DateTime.Now.ToString("d"),
                    Vaccinated = DateTime.Now.AddDays(-37).ToString("d"),
                    ID = defaults.Count + 1,
                    DateOfBirth = rnd.Next(1, 28) + "." + rnd.Next(1, 12) + "." + rnd.Next(1990, 2010),
                    Sex = "male",
                    Address = "My Fancy Street No." + rnd.Next(1, 150),
                    Phone = "0" + rnd.Next(10000000, 99999999).ToString(),
                    EMail = "albus@dumbledore.com",
                });
                defaults.Add(new Person()
                {
                    FirstName = "Severus",
                    LastName = "Snape",
                    Created = DateTime.Now.ToString("d"),
                    MigrationBackground = false,
                    Sex = "male",
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
                    Sex = "male",
                    Tested = DateTime.Now.AddHours(-27).ToString("g"),
                    Created = DateTime.Now.ToString("d"),
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
                    Sex = "female",
                    Created = DateTime.Now.ToString("d"),
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
                    Sex = "male",
                    Tested = DateTime.Now.AddHours(-14).ToString("g"),
                    Created = DateTime.Now.ToString("d"),
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
            CreateStatsTable();

            ReadTable();
            ReadLog();
            ReadStats();
        }
        public static string LogName()
        {
            string log_num = "1";
            return DateTime.Now.ToString("d") + " Log " + "No." + log_num;
        }
        public static string StatsName()
        {
            return DateTime.Now.ToString("d");
        }
        public static int StatsID()
        {
            return G.LastStatID;
        }
        public static bool EntryExists(SQLiteConnection connection, int ID, string tbl = "Person")
        {
            SQLiteCommand existing = new SQLiteCommand($"SELECT count(*) FROM '" + tbl + $"' WHERE ID='{ID}'", connection);
            int count = Convert.ToInt32(existing.ExecuteScalar());
            Console.WriteLine("Exists Check: " + count);
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
                Console.WriteLine("Create Person Table.");
                string tbl = "create table Person (ID integer primary key autoincrement, FirstName text, LastName text, Sex text, MigrationBackground text, DateOfBirth text, Address text, Phone text, EMail text, Note text, Tested text, Vaccinated text, Created text)";
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
                Console.WriteLine("Stats Table.");
                string Age_18_27 = "Age_18_27_divers integer, Age_18_27_male integer, Age_18_27_female integer, Age_18_27_migration_background integer";
                string Age_13_17 = "Age_13_17_divers integer, Age_13_17_male integer, Age_13_17_female integer, Age_13_17_migration_background integer";
                string Age_6_12 = "Age_6_12_divers integer, Age_6_12_male integer, Age_6_12_female integer, Age_6_12_migration_background integer";
                string tbl = "create table '" + "Statistic" + "' (ID integer primary key autoincrement, Date text, "+ Age_6_12+ ", " + Age_13_17 + ", "+ Age_18_27 +" )";
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

                while (reader.Read())
                {
                    Console.WriteLine("Read Stats ...");
                    Stat stat = new Stat();
                    stat.ID = int.Parse(reader["ID"].ToString());
                    stat.Date = DateTime.Parse(reader["Date"].ToString());

                    stat.Age_6_12.divers = int.Parse(reader["Age_6_12_divers"].ToString());
                    stat.Age_6_12.male = int.Parse(reader["Age_6_12_male"].ToString());
                    stat.Age_6_12.female = int.Parse(reader["Age_6_12_female"].ToString());
                    stat.Age_6_12.migration_background = int.Parse(reader["Age_6_12_migration_background"].ToString());

                    stat.Age_13_17.divers = int.Parse(reader["Age_13_17_divers"].ToString());
                    stat.Age_13_17.male = int.Parse(reader["Age_13_17_male"].ToString());
                    stat.Age_13_17.female = int.Parse(reader["Age_13_17_female"].ToString());
                    stat.Age_13_17.migration_background = int.Parse(reader["Age_13_17_migration_background"].ToString());

                    stat.Age_18_27.divers = int.Parse(reader["Age_18_27_divers"].ToString());
                    stat.Age_18_27.male = int.Parse(reader["Age_18_27_male"].ToString());
                    stat.Age_18_27.female = int.Parse(reader["Age_18_27_female"].ToString());
                    stat.Age_18_27.migration_background = int.Parse(reader["Age_18_27_migration_background"].ToString());

                    stat.Add();

                    G.CurrentStat = stat;
                }
                Console.WriteLine("Stats Read!");
            }
        }
        public static void UpdateStat(Stat s)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            Console.WriteLine("Update StatsID: " + StatsID() + "!");

            if (EntryExists(connection, StatsID(), "Statistic"))
            {
                Console.WriteLine("Update Stats!");
                string Age_6_12 = $"Age_6_12_divers='{s.Age_6_12.divers}', Age_6_12_male='{s.Age_6_12.male}', Age_6_12_female='{s.Age_6_12.female}', Age_6_12_migration_background='{s.Age_6_12.migration_background}'";
                string Age_13_17 = $"Age_13_17_divers='{s.Age_13_17.divers}', Age_13_17_male='{s.Age_13_17.male}', Age_13_17_female='{s.Age_13_17.female}', Age_13_17_migration_background='{s.Age_13_17.migration_background}'";
                string Age_18_27 = $"Age_18_27_divers='{s.Age_18_27.divers}', Age_18_27_male='{s.Age_18_27.male}', Age_18_27_female='{s.Age_18_27.female}', Age_18_27_migration_background='{s.Age_18_27.migration_background}'";
                string updatestat= $"update Statistic set Date='{StatsName()}', " + Age_6_12 + ", " + Age_13_17   + ", " + Age_18_27 + $" where id={s.ID};";
                SQLiteCommand command = new SQLiteCommand(updatestat, connection);
                command.ExecuteNonQuery();
            }
            else
            {
                G.LastStatID = Math.Max(StatsID(), G.LastStatID);
                Console.WriteLine("Add Stats!");
                string Age_18_27 = "Age_18_27_divers, Age_18_27_male, Age_18_27_female, Age_18_27_migration_background";
                string Age_13_17 = "Age_13_17_divers, Age_13_17_male, Age_13_17_female, Age_13_17_migration_background";
                string Age_6_12 = "Age_6_12_divers, Age_6_12_male, Age_6_12_female, Age_6_12_migration_background";

                string Age_6_12_values= $"'{s.Age_6_12.divers}', '{s.Age_6_12.male}', '{s.Age_6_12.female}','{s.Age_6_12.migration_background}'";
                string Age_13_17_values = $"'{s.Age_13_17.divers}', '{s.Age_13_17.male}', '{s.Age_13_17.female}','{s.Age_13_17.migration_background}'";
                string Age_18_27_values = $"'{s.Age_18_27.divers}', '{s.Age_18_27.male}', '{s.Age_18_27.female}','{s.Age_18_27.migration_background}'";
                string addstat = $"insert into Statistic (ID, Date, " + Age_6_12 + ", " + Age_13_17 + ", " + Age_18_27 + $") values ({s.ID}, '{s.Date.ToString("d")}', " + Age_6_12_values+ ", " + Age_13_17_values + ", " + Age_18_27_values + ");";
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
                Console.WriteLine("Create Log Table.");
                string tbl = "create table '" + LogName() + "' (ID integer primary key, Time text, FirstName text, LastName text, DateOfBirth text, Address text, Phone text, EMail text)";
                Console.WriteLine(tbl);
                SQLiteCommand command = new SQLiteCommand(tbl, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
        public static void AddVisit(Person p)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            if (!EntryExists(connection, p.ID, LogName()))
            {
                G.LastID = Math.Max(p.getID, G.LastID);
                string addperson = $"insert into '" + LogName() + $"' (ID, Time, FirstName, LastName, DateOfBirth, Address, Phone, EMail) values ({p.getID}, '{p.VisitTime}', '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}');";
                SQLiteCommand command = new SQLiteCommand(addperson, connection);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
        public static void DeleteVisit(Person p)
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();
            if (EntryExists(connection, p.ID, LogName()))
            {
                Console.WriteLine("Delete DB Row with ID: " + p.getID);
                string deleteperson = $"delete from '" + LogName() + $"' where id={p.getID};";
                SQLiteCommand command = new SQLiteCommand(deleteperson, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
        public static void ReadLog()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            using (SQLiteConnection connection = new SQLiteConnection(dbfile))
            {
                connection.Open();
                SQLiteCommand cmd = new SQLiteCommand("select * from '" + LogName() + "'", connection);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("Read Logs ...");

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
                    foreach(Person person in G.People)
                    {
                        if (person.EqualsPerson(p))
                        {
                            person.VisitTime = p.VisitTime;
                            person.statAdded = true;
                            person._statAdded = true;
                            person.AddVisit();
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        p.Add();
                        p.statAdded = true;
                        p._statAdded = true;
                        p.AddVisit();
                    }
                }

                Console.WriteLine("Logs Read!");
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
                string addperson = $"insert into Person (ID, FirstName, LastName, Sex, DateOfBirth, MigrationBackground, Address, Phone, EMail, Note, Tested, Vaccinated, Created) values ({p.getID}, '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.Sex)}','{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.MigrationBackground.ToString())}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}', '{Encryption.Encrypt(p.Note)}', '{Encryption.Encrypt(p.Tested)}', '{Encryption.Encrypt(p.Vaccinated)}', '{Encryption.Encrypt(p.Created)}');";
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
                Console.WriteLine("Delete DB Row with ID: " + p.getID);
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
                string updateperson = $"update Person set FirstName='{Encryption.Encrypt(p.FirstName)}', LastName='{Encryption.Encrypt(p.LastName)}', Sex='{Encryption.Encrypt(p.Sex)}', DateOfBirth='{Encryption.Encrypt(p.DateOfBirth)}', MigrationBackground={Encryption.Encrypt(p.MigrationBackground.ToString())}, Address='{Encryption.Encrypt(p.Address)}', Phone='{Encryption.Encrypt(p.Phone)}', EMail='{Encryption.Encrypt(p.EMail)}', Note='{Encryption.Encrypt(p.Note)}', Tested='{Encryption.Encrypt(p.Tested)}', Vaccinated='{Encryption.Encrypt(p.Vaccinated)}', Created='{Encryption.Encrypt(p.Created)}' where id={p.getID};";
                SQLiteCommand command = new SQLiteCommand(updateperson, connection);
                command.ExecuteNonQuery();
            }
            else
            {
                G.LastID = Math.Max(p.getID, G.LastID);
                string addperson = $"insert into Person (ID, FirstName, LastName, Sex, DateOfBirth, MigrationBackground, Address, Phone, EMail, Note, Tested, Vaccinated, Created) values ({p.getID}, '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.Sex)}', '{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.MigrationBackground.ToString())}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}', '{Encryption.Encrypt(p.Note)}', '{Encryption.Encrypt(p.Tested)}', '{Encryption.Encrypt(p.Vaccinated)}', '{Encryption.Encrypt(p.Created)}');";
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

                while (reader.Read())
                {
                    Console.WriteLine("Read People ...");

                    Person p = new Person();
                    p.ID = int.Parse(reader["ID"].ToString());
                    p.FirstName = Encryption.Decrypt(reader["FirstName"].ToString());
                    p.LastName = Encryption.Decrypt(reader["LastName"].ToString());
                    p.MigrationBackground = bool.Parse(Encryption.Decrypt(reader["MigrationBackground"].ToString()));
                    p.Sex = Encryption.Decrypt(reader["Sex"].ToString());
                    p.DateOfBirth = Encryption.Decrypt(reader["DateOfBirth"].ToString());
                    p.Address = Encryption.Decrypt(reader["Address"].ToString());
                    p.Phone = Encryption.Decrypt(reader["Phone"].ToString());
                    p.EMail = Encryption.Decrypt(reader["EMail"].ToString());
                    p.Note = Encryption.Decrypt(reader["Note"].ToString());
                    p.Tested = Encryption.Decrypt(reader["Tested"].ToString());
                    p.Vaccinated = Encryption.Decrypt(reader["Vaccinated"].ToString());
                    p.Created = Encryption.Decrypt(reader["Created"].ToString());

                    p.Add();
                }
                Console.WriteLine("People Read!");

                if (TableExists("sqlite_sequence", connection)) { 
                    SQLiteCommand cmd2 = new SQLiteCommand("select * from sqlite_sequence", connection);
                SQLiteDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                    {
                        Console.WriteLine("Read Increments ...");

                        if (reader2["name"].ToString() == "Person")
                    {
                        G.LastID = int.Parse(reader2["seq"].ToString());
                        Console.WriteLine("Last assigned ID: " + G.LastID);
                    }

                    if (reader2["name"].ToString() == "Statistic")
                    {
                        G.LastID = int.Parse(reader2["seq"].ToString());
                        Console.WriteLine("Last assigned Stat ID: " + G.LastStatID);
                    }
                    }
                    Console.WriteLine("Increments Read!");
                }
            }
        }
    }
}
