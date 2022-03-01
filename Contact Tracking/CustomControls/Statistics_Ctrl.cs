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

            Language.Actions.Add(new Language.Entry() { action = LoadLanguage, name = "Statistics Ctrl", initialized = true });
        }

        public void LoadLanguage()
        {
            Header.Text = Properties.strings.VisitorStats;
            Export.Text = Properties.strings.Export;

            //set Strings
            Age_6_13.Series["male"].LegendText = Properties.strings.male;
            Age_6_13.Series["female"].LegendText = Properties.strings.female;
            Age_6_13.Series["divers"].LegendText = Properties.strings.divers;
            Age_6_13.Series["migration"].LegendText = Properties.strings.migration_background;

            Age_14_17.Series["male"].LegendText = Properties.strings.male;
            Age_14_17.Series["female"].LegendText = Properties.strings.female;
            Age_14_17.Series["divers"].LegendText = Properties.strings.divers;
            Age_14_17.Series["migration"].LegendText = Properties.strings.migration_background;

            Age_18_Plus.Series["male"].LegendText = Properties.strings.male;
            Age_18_Plus.Series["female"].LegendText = Properties.strings.female;
            Age_18_Plus.Series["divers"].LegendText = Properties.strings.divers;
            Age_18_Plus.Series["migration"].LegendText = Properties.strings.migration_background;
        }

        public void AddEntry(Stat stat)
        {
            if (stat.index <= 0)
            {
                stat.index = Age_6_13.Series["male"].Points.Count + 1;
            }

            var Date = stat.Name;

            //add Stats from 6-12
            Age_6_13.Series["male"].Points.AddXY(Date, stat.Age_6_13.male);
            Age_6_13.Series["female"].Points.AddXY(Date, stat.Age_6_13.female);
            Age_6_13.Series["divers"].Points.AddXY(Date, stat.Age_6_13.divers);
            Age_6_13.Series["migration"].Points.AddXY(Date, stat.Age_6_13.migration_background);
            Age_6_13.ChartAreas[0].RecalculateAxesScale();

            //add Stats from 13-17
            Age_14_17.Series["male"].Points.AddXY(Date, stat.Age_14_17.male);
            Age_14_17.Series["female"].Points.AddXY(Date, stat.Age_14_17.female);
            Age_14_17.Series["divers"].Points.AddXY(Date, stat.Age_14_17.divers);
            Age_14_17.Series["migration"].Points.AddXY(Date, stat.Age_14_17.migration_background);
            Age_14_17.ChartAreas[0].RecalculateAxesScale();

            //add Stats from 18-27
            Age_18_Plus.Series["male"].Points.AddXY(Date, stat.Age_18_Plus.male);
            Age_18_Plus.Series["female"].Points.AddXY(Date, stat.Age_18_Plus.female);
            Age_18_Plus.Series["divers"].Points.AddXY(Date, stat.Age_18_Plus.divers);
            Age_18_Plus.Series["migration"].Points.AddXY(Date, stat.Age_18_Plus.migration_background);
            Age_18_Plus.ChartAreas[0].RecalculateAxesScale();
        }

        public void RefreshStats(Stat stat)
        {
            int i = stat.index -1;

             if (i > -1)
            {
                Age_6_13.Series["male"].Points[i].SetValueY(stat.Age_6_13.male);
                Age_6_13.Series["female"].Points[i].SetValueY(stat.Age_6_13.female);
                Age_6_13.Series["divers"].Points[i].SetValueY(stat.Age_6_13.divers);
                Age_6_13.Series["migration"].Points[i].SetValueY(stat.Age_6_13.migration_background);
                Age_6_13.ChartAreas[0].RecalculateAxesScale();

                Age_14_17.Series["male"].Points[i].SetValueY(stat.Age_14_17.male);
                Age_14_17.Series["female"].Points[i].SetValueY(stat.Age_14_17.female);
                Age_14_17.Series["divers"].Points[i].SetValueY(stat.Age_14_17.divers);
                Age_14_17.Series["migration"].Points[i].SetValueY(stat.Age_14_17.migration_background);
                Age_14_17.ChartAreas[0].RecalculateAxesScale();

                Age_18_Plus.Series["male"].Points[i].SetValueY(stat.Age_18_Plus.male);
                Age_18_Plus.Series["female"].Points[i].SetValueY(stat.Age_18_Plus.female);
                Age_18_Plus.Series["divers"].Points[i].SetValueY(stat.Age_18_Plus.divers);
                Age_18_Plus.Series["migration"].Points[i].SetValueY(stat.Age_18_Plus.migration_background);
                Age_18_Plus.ChartAreas[0].RecalculateAxesScale();
            }
             else
            {
                AddEntry(stat);
            }
        }

        public class ExportStat
        {
            public double Date { get; set; }
            public int Age_6_13_male { get; set; }
            public int Age_6_13_female { get; set; }
            public int Age_6_13_divers { get; set; }
            public int Age_6_13_migration_background { get; set; } 
            public int Age_14_17_male { get; set; } 
            public int Age_14_17_female { get; set; }
            public int Age_14_17_divers { get; set; }
            public int Age_14_17_migration_background { get; set; }
            public int Age_18_Plus_male { get; set; }
            public int Age_18_Plus_female { get; set; }
            public int Age_18_Plus_divers { get; set; }
            public int Age_18_Plus_migration_background { get; set; }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            //Stat stat = G.CurrentStat;

            var records = new List<ExportStat>();

            foreach(Stat stat in G.Stats)
            {
                ExportStat export = new ExportStat();
                export.Date = Math.Floor(stat.Date.ToOADate());

                export.Age_6_13_male = stat.Age_6_13.male;
                export.Age_6_13_female = stat.Age_6_13.female;
                export.Age_6_13_divers = stat.Age_6_13.divers;
                export.Age_6_13_migration_background = stat.Age_6_13.migration_background;

                export.Age_14_17_male = stat.Age_14_17.male;
                export.Age_14_17_female = stat.Age_14_17.female;
                export.Age_14_17_divers = stat.Age_14_17.divers;
                export.Age_14_17_migration_background = stat.Age_14_17.migration_background;

                export.Age_18_Plus_male = stat.Age_18_Plus.male;
                export.Age_18_Plus_female = stat.Age_18_Plus.female;
                export.Age_18_Plus_divers = stat.Age_18_Plus.divers;
                export.Age_18_Plus_migration_background = stat.Age_18_Plus.migration_background;

                records.Add(export);
            }


            using (var writer = new StreamWriter(Properties.Settings.Default.DataPath + @"\Statistics.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(records);
            }
        }
    }
}
