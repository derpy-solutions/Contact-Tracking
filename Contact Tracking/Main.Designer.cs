
namespace Contact_Tracking
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.RunLoop = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statistics_Tab = new Contact_Tracking.Custom_Controls.Statistics_Ctrl();
            this.SideBar = new Contact_Tracking.Custom_Controls.SideBar();
            this.tracking = new Contact_Tracking.Custom_Controls.TrackingTab();
            this.restartPopUp = new Contact_Tracking.Custom_Controls.RestartPopUp();
            this.settings = new Contact_Tracking.Custom_Controls.Settings();
            this.personCard = new Contact_Tracking.Custom_Controls.PersonCard();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 100;
            // 
            // statistics_Tab
            // 
            this.statistics_Tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statistics_Tab.BackColor = System.Drawing.Color.Transparent;
            this.statistics_Tab.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statistics_Tab.ForeColor = System.Drawing.Color.White;
            this.statistics_Tab.Location = new System.Drawing.Point(86, 0);
            this.statistics_Tab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.statistics_Tab.Name = "statistics_Tab";
            this.statistics_Tab.Size = new System.Drawing.Size(1070, 795);
            this.statistics_Tab.TabIndex = 25;
            this.statistics_Tab.Visible = false;
            // 
            // SideBar
            // 
            this.SideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.SideBar.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.SideBar.ForeColor = System.Drawing.Color.White;
            this.SideBar.Location = new System.Drawing.Point(0, 0);
            this.SideBar.Margin = new System.Windows.Forms.Padding(4);
            this.SideBar.MaximumSize = new System.Drawing.Size(300, 1000000000);
            this.SideBar.MinimumSize = new System.Drawing.Size(85, 200);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(85, 799);
            this.SideBar.TabIndex = 17;
            // 
            // tracking
            // 
            this.tracking.active_personListItem = null;
            this.tracking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tracking.BackColor = System.Drawing.Color.Transparent;
            this.tracking.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.tracking.ForeColor = System.Drawing.Color.Black;
            this.tracking.Location = new System.Drawing.Point(86, 0);
            this.tracking.Margin = new System.Windows.Forms.Padding(0);
            this.tracking.Name = "tracking";
            this.tracking.Size = new System.Drawing.Size(1070, 799);
            this.tracking.TabIndex = 22;
            // 
            // restartPopUp
            // 
            this.restartPopUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.restartPopUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.restartPopUp.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.restartPopUp.Location = new System.Drawing.Point(416, 107);
            this.restartPopUp.Margin = new System.Windows.Forms.Padding(4);
            this.restartPopUp.Name = "restartPopUp";
            this.restartPopUp.Size = new System.Drawing.Size(517, 201);
            this.restartPopUp.TabIndex = 21;
            this.restartPopUp.Visible = false;
            this.restartPopUp.VisibleChanged += new System.EventHandler(this.restartPopUp_VisibleChanged);
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(93, 13);
            this.settings.Margin = new System.Windows.Forms.Padding(4);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(150, 150);
            this.settings.TabIndex = 24;
            this.settings.Visible = false;
            // 
            // personCard
            // 
            this.personCard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.personCard.AutoScroll = true;
            this.personCard.BackColor = System.Drawing.Color.Transparent;
            this.personCard.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.personCard.ForeColor = System.Drawing.Color.White;
            this.personCard.Location = new System.Drawing.Point(86, 0);
            this.personCard.Margin = new System.Windows.Forms.Padding(4);
            this.personCard.Name = "personCard";
            this.personCard.Size = new System.Drawing.Size(1070, 795);
            this.personCard.TabIndex = 23;
            this.personCard.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(1159, 797);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.tracking);
            this.Controls.Add(this.restartPopUp);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.personCard);
            this.Controls.Add(this.statistics_Tab);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1175, 585);
            this.Name = "Main";
            this.Text = "Contact Tracking";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing_1);
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_MouseClick);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        public System.ComponentModel.BackgroundWorker RunLoop;
        public System.Windows.Forms.ToolTip toolTip1;
        private Custom_Controls.SideBar SideBar;
        public Custom_Controls.RestartPopUp restartPopUp;
        public Custom_Controls.TrackingTab tracking;
        public Custom_Controls.PersonCard personCard;
        public Custom_Controls.Settings settings;
        private Custom_Controls.Statistics_Ctrl statistics_Tab;
    }
}