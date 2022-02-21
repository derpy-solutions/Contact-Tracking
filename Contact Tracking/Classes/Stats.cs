using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_Tracking
{
    public class Stats
    {
        public class Age_13_17
        {
            public string age_span = "Age_13_17";
            public int female = 0;
            public int divers = 0;
            public int male = 0;
            public int migration_background = 0;

        }
        public class Age_6_12
        {
            public string age_span = "Age_6_12";
            public int female = 0;
            public int divers = 0;
            public int male = 0;
            public int migration_background = 0;
        }
        public class Age_18_27
        {
            public string age_span = "Age_18_27";
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
        public int ID;
        public int index;
        public DateTime Date;
        public Stats.Age_6_12 Age_6_12 = new Stats.Age_6_12();
        public Stats.Age_13_17 Age_13_17 = new Stats.Age_13_17();
        public Stats.Age_18_27 Age_18_27 = new Stats.Age_18_27();
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
