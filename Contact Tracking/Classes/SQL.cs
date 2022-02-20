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
           if  (CreateTable())
            {
                Random rnd = new Random();

                List<Person> defaults = new List<Person>();
                defaults.Add(new Person()
                {
                    FirstName = "Albus",
                    LastName = "Dumbledore",
                    SaveProof = true,
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
                    SaveProof = true,
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
                    Vaccinated = "01.01.2020",
                    Sex = "male",
                    SaveProof = true,
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
                    Sex = "female",
                    SaveProof = true,
                    Vaccinated = "01.01.2020",
                    ID = defaults.Count + 1,
                    DateOfBirth = rnd.Next(1, 28) + "." + rnd.Next(1, 12) + "." + rnd.Next(1990, 2010),
                    Address = "My Fancy Street No." + rnd.Next(1, 150),
                    Phone = "0" + rnd.Next(10000000, 99999999).ToString(),
                    EMail = "hermine@granger.com",
                });
                defaults.Add(new Person()
                {
                    FirstName = "Ron",
                    LastName = "Weasley",
                    Sex = "male",
                    Tested = "01.01.2020 12:00:00",
                    SaveProof = true,
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

            ReadTable();
            ReadLog();
        }
        public static string LogName()
        {
            string log_num = "1";
            return DateTime.Now.ToString("d") + " Log " + "No." + log_num;
        }
        public static bool EntryExists(SQLiteConnection connection, Person p, string tbl = "Person")
        {
            SQLiteCommand existing = new SQLiteCommand($"SELECT count(*) FROM '" + tbl + $"' WHERE ID='{p.getID}'", connection);
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
                string tbl = "create table Person (ID integer primary key autoincrement, FirstName text, LastName text, Sex text, DateOfBirth text, Address text, Phone text, EMail text, Note text, Tested text, Vaccinated text, SaveProof text, QRCode blob)";
                SQLiteCommand command = new SQLiteCommand(tbl, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }
        public static bool CreateLogsTable()
        {
            string dbfile = "URI=file:" + Properties.Settings.Default.DataPath + @"\data.db";
            SQLiteConnection connection = new SQLiteConnection(dbfile);
            connection.Open();           

            if (!TableExists(LogName(), connection))
            {
                Console.WriteLine("Create Log Table.");
                string tbl = "create table '" + LogName() + "' (ID integer primary key, Time text, FirstName text, LastName text, Sex text, DateOfBirth text, Address text, Phone text, EMail text)";
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
            if (!EntryExists(connection, p, LogName()))
            {
                G.LastID = Math.Max(p.getID, G.LastID);
                string addperson = $"insert into '" + LogName() + $"' (ID, Time, FirstName, LastName, Sex, DateOfBirth, Address, Phone, EMail) values ({p.getID}, '{p.VisitTime}', '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.Sex)}', '{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}');";
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
            Console.WriteLine("EntryExists: " + EntryExists(connection, p, LogName()));
            if (EntryExists(connection, p, LogName()))
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
                    Person p = new Person();
                    p.ID = int.Parse(reader["ID"].ToString());
                    p.VisitTime = reader["Time"].ToString();
                    p.FirstName = Encryption.Decrypt(reader["FirstName"].ToString());
                    p.LastName = Encryption.Decrypt(reader["LastName"].ToString());
                    p.Sex = Encryption.Decrypt(reader["Sex"].ToString());
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
                            person.AddVisit();
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        p.Add();
                        p.AddVisit();
                    }
                }

                if (TableExists("sqlite_sequence", connection))
                {
                    SQLiteCommand cmd2 = new SQLiteCommand("select * from sqlite_sequence", connection);
                    SQLiteDataReader reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        if (reader2["name"].ToString() == "Person")
                        {
                            G.LastID = int.Parse(reader2["seq"].ToString());
                            Console.WriteLine("Last assigned ID: " + G.LastID);
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
            if (!EntryExists(connection, p))
            {
                G.LastID = Math.Max(p.getID, G.LastID);
                string addperson = $"insert into Person (ID, FirstName, LastName, Sex, DateOfBirth, Address, Phone, EMail, Note, Tested, Vaccinated, SaveProof) values ({p.getID}, '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.Sex)}','{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}', '{Encryption.Encrypt(p.Note)}', '{Encryption.Encrypt(p.Tested)}', '{Encryption.Encrypt(p.Vaccinated)}', '{Encryption.Encrypt(p.SaveProof.ToString())}');";
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
            if (EntryExists(connection, p))
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
            
            if (EntryExists(connection, p))
            {
                Console.WriteLine("Update Person!");
                string updateperson = $"update Person set FirstName='{Encryption.Encrypt(p.FirstName)}', LastName='{Encryption.Encrypt(p.LastName)}', Sex='{Encryption.Encrypt(p.Sex)}', DateOfBirth='{Encryption.Encrypt(p.DateOfBirth)}', Address='{Encryption.Encrypt(p.Address)}', Phone='{Encryption.Encrypt(p.Phone)}', EMail='{Encryption.Encrypt(p.EMail)}', Note='{Encryption.Encrypt(p.Note)}', Tested='{Encryption.Encrypt(p.Tested)}', Vaccinated='{Encryption.Encrypt(p.Vaccinated)}', SaveProof='{Encryption.Encrypt(p.SaveProof.ToString())}' where id={p.getID};";
                Console.WriteLine(updateperson);
                SQLiteCommand command = new SQLiteCommand(updateperson, connection);
                command.ExecuteNonQuery();
            }
            else
            {
                G.LastID = Math.Max(p.getID, G.LastID);
                string addperson = $"insert into Person (ID, FirstName, LastName, Sex, DateOfBirth, Address, Phone, EMail, Note, Tested, Vaccinated, SaveProof) values ({p.getID}, '{Encryption.Encrypt(p.FirstName)}', '{Encryption.Encrypt(p.LastName)}', '{Encryption.Encrypt(p.Sex)}', '{Encryption.Encrypt(p.DateOfBirth)}', '{Encryption.Encrypt(p.Address)}', '{Encryption.Encrypt(p.Phone)}', '{Encryption.Encrypt(p.EMail)}', '{Encryption.Encrypt(p.Note)}', '{Encryption.Encrypt(p.Tested)}', '{Encryption.Encrypt(p.Vaccinated)}', '{Encryption.Encrypt(p.SaveProof.ToString())}');";
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
                    Person p = new Person();
                    p.ID = int.Parse(reader["ID"].ToString());
                    p.FirstName = Encryption.Decrypt(reader["FirstName"].ToString());
                    p.LastName = Encryption.Decrypt(reader["LastName"].ToString());
                    p.Sex = Encryption.Decrypt(reader["Sex"].ToString());
                    p.DateOfBirth = Encryption.Decrypt(reader["DateOfBirth"].ToString());
                    p.Address = Encryption.Decrypt(reader["Address"].ToString());
                    p.Phone = Encryption.Decrypt(reader["Phone"].ToString());
                    p.EMail = Encryption.Decrypt(reader["EMail"].ToString());
                    p.Note = Encryption.Decrypt(reader["Note"].ToString());
                    p.Tested = Encryption.Decrypt(reader["Tested"].ToString());
                    p.Vaccinated = Encryption.Decrypt(reader["Vaccinated"].ToString());
                    p.SaveProof = bool.Parse(Encryption.Decrypt(reader["SaveProof"].ToString()));

                    p.Add();
                }

                if (TableExists("sqlite_sequence", connection)) { 
                    SQLiteCommand cmd2 = new SQLiteCommand("select * from sqlite_sequence", connection);
                SQLiteDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2["name"].ToString() == "Person")
                    {
                        G.LastID = int.Parse(reader2["seq"].ToString());
                        Console.WriteLine("Last assigned ID: " + G.LastID);
                    }
                }
            }
            }
        }
    }
}
