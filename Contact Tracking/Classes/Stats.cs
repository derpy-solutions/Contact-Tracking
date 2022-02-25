using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Tracking
{
    public class Stats
    {
        public class Age_14_17
        {
            public string age_span = "Age_14_17";
            public int female = 0;
            public int divers = 0;
            public int male = 0;
            public int migration_background = 0;

        }
        public class Age_6_13
        {
            public string age_span = "Age_6_13";
            public int female = 0;
            public int divers = 0;
            public int male = 0;
            public int migration_background = 0;
        }
        public class Age_18_Plus
        {
            public string age_span = "Age_18_Plus";
            public int female = 0;
            public int divers = 0;
            public int male = 0;
            public int migration_background = 0;
        }

        public void Export()
        {
            if (G.Stats.Count > 0)
            {

            }
        }
    }

    public class Stat
    {
        private int _ID;
        private bool split;
        public int ID {
            get {
                return _ID;
            }
            set {
                _ID = value;
            }
        }
        public string _Name;
        private DateTime _Date;
        public string Name {
            get {
                if (_Name == null)
                {
                    _Name = SQL.StatsName();
                }
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public int index;
        public List <int> People = new List<int>();
        public DateTime Date
        {
            get
            {
                if (_Date == G.DateZero)
                {
                    _Date = DateTime.Parse(DateTime.Now.ToString("d") + " 00:00:00");
                }

                return _Date;
            }
            set
            {
                _Date = value;
            }
        }
        public Stats.Age_6_13 Age_6_13 = new Stats.Age_6_13();
        public Stats.Age_14_17 Age_14_17 = new Stats.Age_14_17();
        public Stats.Age_18_Plus Age_18_Plus = new Stats.Age_18_Plus();
        public void Add() 
        {
            G.Stats.Add(this);
            MyControls.Stats.AddEntry(this);
        }
        public void Refresh() 
        {

        }
    }
}
