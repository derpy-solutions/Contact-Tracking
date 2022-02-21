using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CsvHelper;

namespace Contact_Tracking.Custom_Controls
{
    public partial class Statistics_Ctrl : UserControl
    {
        public Statistics_Ctrl()
        {
            InitializeComponent();

            //set Strings
            Age_6_12.Series["male"].LegendText = Properties.strings.male;
            Age_6_12.Series["female"].LegendText = Properties.strings.female;
            Age_6_12.Series["divers"].LegendText = Properties.strings.divers;
            Age_6_12.Series["migration"].LegendText = Properties.strings.migration_background;

            Age_13_17.Series["male"].LegendText = Properties.strings.male;
            Age_13_17.Series["female"].LegendText = Properties.strings.female;
            Age_13_17.Series["divers"].LegendText = Properties.strings.divers;
            Age_13_17.Series["migration"].LegendText = Properties.strings.migration_background;

            Age_18_27.Series["male"].LegendText = Properties.strings.male;
            Age_18_27.Series["female"].LegendText = Properties.strings.female;
            Age_18_27.Series["divers"].LegendText = Properties.strings.divers;
            Age_18_27.Series["migration"].LegendText = Properties.strings.migration_background;

            Header.Text = Properties.strings.VisitorStats;
            Export.Text = Properties.strings.Export;
        }

        public void AddEntry(Stat stat)
        {
            if (stat.index <= 0)
            {
                stat.index = Age_6_12.Series["male"].Points.Count + 1;
                Console.WriteLine("Set New Stat Index for Stat ID: " + stat.ID + " new index is: " + stat.index);
            }

            var Date = stat.Date.ToString("d");

            Console.WriteLine("Adding stat ID: " + stat.ID + " from " + Date);
            //add Stats from 6-12
            Age_6_12.Series["male"].Points.AddXY(Date, stat.Age_6_12.male);
            Age_6_12.Series["female"].Points.AddXY(Date, stat.Age_6_12.female);
            Age_6_12.Series["divers"].Points.AddXY(Date, stat.Age_6_12.divers);
            Age_6_12.Series["migration"].Points.AddXY(Date, stat.Age_6_12.migration_background);
            Age_6_12.ChartAreas[0].RecalculateAxesScale();

            //add Stats from 13-17
            Age_13_17.Series["male"].Points.AddXY(Date, stat.Age_13_17.male);
            Age_13_17.Series["female"].Points.AddXY(Date, stat.Age_13_17.female);
            Age_13_17.Series["divers"].Points.AddXY(Date, stat.Age_13_17.divers);
            Age_13_17.Series["migration"].Points.AddXY(Date, stat.Age_13_17.migration_background);
            Age_13_17.ChartAreas[0].RecalculateAxesScale();

            //add Stats from 18-27
            Age_18_27.Series["male"].Points.AddXY(Date, stat.Age_18_27.male);
            Age_18_27.Series["female"].Points.AddXY(Date, stat.Age_18_27.female);
            Age_18_27.Series["divers"].Points.AddXY(Date, stat.Age_18_27.divers);
            Age_18_27.Series["migration"].Points.AddXY(Date, stat.Age_18_27.migration_background);
            Age_18_27.ChartAreas[0].RecalculateAxesScale();
        }

        public void RefreshStats(Stat stat)
        {
            int i = stat.index -1;

             if (i > -1)
            {
                Age_6_12.Series["male"].Points[i].SetValueY(stat.Age_6_12.male);
                Age_6_12.Series["female"].Points[i].SetValueY(stat.Age_6_12.female);
                Age_6_12.Series["divers"].Points[i].SetValueY(stat.Age_6_12.divers);
                Age_6_12.Series["migration"].Points[i].SetValueY(stat.Age_6_12.migration_background);
                Age_6_12.ChartAreas[0].RecalculateAxesScale();

                Age_13_17.Series["male"].Points[i].SetValueY(stat.Age_13_17.male);
                Age_13_17.Series["female"].Points[i].SetValueY(stat.Age_13_17.female);
                Age_13_17.Series["divers"].Points[i].SetValueY(stat.Age_13_17.divers);
                Age_13_17.Series["migration"].Points[i].SetValueY(stat.Age_13_17.migration_background);
                Age_13_17.ChartAreas[0].RecalculateAxesScale();

                Age_18_27.Series["male"].Points[i].SetValueY(stat.Age_18_27.male);
                Age_18_27.Series["female"].Points[i].SetValueY(stat.Age_18_27.female);
                Age_18_27.Series["divers"].Points[i].SetValueY(stat.Age_18_27.divers);
                Age_18_27.Series["migration"].Points[i].SetValueY(stat.Age_18_27.migration_background);
                Age_18_27.ChartAreas[0].RecalculateAxesScale();
            }
             else
            {
                AddEntry(stat);
            }
        }

        public class ExportStat
        {
            public double Date { get; set; }
            public int Age_6_12_male { get; set; }
            public int Age_6_12_female { get; set; }
            public int Age_6_12_divers { get; set; }
            public int Age_6_12_migration_background { get; set; } 
            public int Age_13_17_male { get; set; } 
            public int Age_13_17_female { get; set; }
            public int Age_13_17_divers { get; set; }
            public int Age_13_17_migration_background { get; set; }
            public int Age_18_27_male { get; set; }
            public int Age_18_27_female { get; set; }
            public int Age_18_27_divers { get; set; }
            public int Age_18_27_migration_background { get; set; }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            //Stat stat = G.CurrentStat;

            var records = new List<ExportStat>();

            foreach(Stat stat in G.Stats)
            {
                ExportStat export = new ExportStat();
                export.Date = Math.Floor(stat.Date.ToOADate());

                export.Age_6_12_male = stat.Age_6_12.male;
                export.Age_6_12_female = stat.Age_6_12.female;
                export.Age_6_12_divers = stat.Age_6_12.divers;
                export.Age_6_12_migration_background = stat.Age_6_12.migration_background;

                export.Age_13_17_male = stat.Age_13_17.male;
                export.Age_13_17_female = stat.Age_13_17.female;
                export.Age_13_17_divers = stat.Age_13_17.divers;
                export.Age_13_17_migration_background = stat.Age_13_17.migration_background;

                export.Age_18_27_male = stat.Age_18_27.male;
                export.Age_18_27_female = stat.Age_18_27.female;
                export.Age_18_27_divers = stat.Age_18_27.divers;
                export.Age_18_27_migration_background = stat.Age_18_27.migration_background;

                records.Add(export);
            }


            using (var writer = new StreamWriter(Properties.Settings.Default.DataPath + $"Statistics.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }
    }
}
