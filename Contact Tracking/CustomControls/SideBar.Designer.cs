
namespace Contact_Tracking.Custom_Controls
{
    partial class SideBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CurrentVersion = new System.Windows.Forms.Label();
            this.SideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.NewestVersion = new System.Windows.Forms.Label();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.NewestLabel = new System.Windows.Forms.Label();
            this.DownloadProgress = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Stats_Button = new System.Windows.Forms.Button();
            this.SideBar_Create = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.UpdateNotification = new System.Windows.Forms.PictureBox();
            this.SideBar_Tracking = new System.Windows.Forms.Button();
            this.SideBar_Settings = new System.Windows.Forms.Button();
            this.SideBar_Menu = new System.Windows.Forms.Button();
            this.CheckForUpdates = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UpdateNotification)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentVersion
            // 
            this.CurrentVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentVersion.AutoSize = true;
            this.CurrentVersion.BackColor = System.Drawing.Color.Transparent;
            this.CurrentVersion.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.CurrentVersion.ForeColor = System.Drawing.Color.White;
            this.CurrentVersion.Location = new System.Drawing.Point(182, 811);
            this.CurrentVersion.Name = "CurrentVersion";
            this.CurrentVersion.Size = new System.Drawing.Size(59, 20);
            this.CurrentVersion.TabIndex = 13;
            this.CurrentVersion.Text = "v. 1.0.0";
            // 
            // SideBarTimer
            // 
            this.SideBarTimer.Interval = 5;
            this.SideBarTimer.Tick += new System.EventHandler(this.SideBarTimer_Tick);
            // 
            // NewestVersion
            // 
            this.NewestVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewestVersion.AutoSize = true;
            this.NewestVersion.BackColor = System.Drawing.Color.Transparent;
            this.NewestVersion.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.NewestVersion.ForeColor = System.Drawing.Color.White;
            this.NewestVersion.Location = new System.Drawing.Point(182, 831);
            this.NewestVersion.Name = "NewestVersion";
            this.NewestVersion.Size = new System.Drawing.Size(38, 20);
            this.NewestVersion.TabIndex = 18;
            this.NewestVersion.Text = "N/A";
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.CurrentLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentLabel.Location = new System.Drawing.Point(106, 811);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(70, 20);
            this.CurrentLabel.TabIndex = 19;
            this.CurrentLabel.Text = "Current:";
            // 
            // NewestLabel
            // 
            this.NewestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewestLabel.BackColor = System.Drawing.Color.Transparent;
            this.NewestLabel.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.NewestLabel.ForeColor = System.Drawing.Color.White;
            this.NewestLabel.Location = new System.Drawing.Point(106, 831);
            this.NewestLabel.Name = "NewestLabel";
            this.NewestLabel.Size = new System.Drawing.Size(70, 20);
            this.NewestLabel.TabIndex = 20;
            this.NewestLabel.Text = "Newest:";
            // 
            // DownloadProgress
            // 
            this.DownloadProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DownloadProgress.Location = new System.Drawing.Point(0, 670);
            this.DownloadProgress.Name = "DownloadProgress";
            this.DownloadProgress.Size = new System.Drawing.Size(300, 10);
            this.DownloadProgress.Step = 1;
            this.DownloadProgress.TabIndex = 22;
            this.DownloadProgress.Visible = false;
            // 
            // Stats_Button
            // 
            this.Stats_Button.BackColor = System.Drawing.Color.Transparent;
            this.Stats_Button.FlatAppearance.BorderSize = 0;
            this.Stats_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Stats_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Stats_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stats_Button.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.Stats_Button.ForeColor = System.Drawing.Color.White;
            this.Stats_Button.Image = global::Contact_Tracking.Properties.Resources.chart;
            this.Stats_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Stats_Button.Location = new System.Drawing.Point(0, 180);
            this.Stats_Button.Margin = new System.Windows.Forms.Padding(0);
            this.Stats_Button.Name = "Stats_Button";
            this.Stats_Button.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.Stats_Button.Size = new System.Drawing.Size(300, 60);
            this.Stats_Button.TabIndex = 25;
            this.Stats_Button.Text = "         Statistik";
            this.Stats_Button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Stats_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Stats_Button.UseVisualStyleBackColor = false;
            this.Stats_Button.Click += new System.EventHandler(this.Stats_Button_Click);
            // 
            // SideBar_Create
            // 
            this.SideBar_Create.BackColor = System.Drawing.Color.Transparent;
            this.SideBar_Create.FlatAppearance.BorderSize = 0;
            this.SideBar_Create.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.SideBar_Create.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.SideBar_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SideBar_Create.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.SideBar_Create.ForeColor = System.Drawing.Color.White;
            this.SideBar_Create.Image = global::Contact_Tracking.Properties.Resources.person_add_36x361;
            this.SideBar_Create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Create.Location = new System.Drawing.Point(0, 120);
            this.SideBar_Create.Margin = new System.Windows.Forms.Padding(0);
            this.SideBar_Create.Name = "SideBar_Create";
            this.SideBar_Create.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.SideBar_Create.Size = new System.Drawing.Size(300, 60);
            this.SideBar_Create.TabIndex = 24;
            this.SideBar_Create.Text = "         Erstellen";
            this.SideBar_Create.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Create.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SideBar_Create.UseVisualStyleBackColor = false;
            this.SideBar_Create.Click += new System.EventHandler(this.SideBar_Create_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpdateButton.BackColor = System.Drawing.Color.Transparent;
            this.UpdateButton.FlatAppearance.BorderSize = 0;
            this.UpdateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.UpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.UpdateButton.ForeColor = System.Drawing.Color.White;
            this.UpdateButton.Image = global::Contact_Tracking.Properties.Resources.download;
            this.UpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.Location = new System.Drawing.Point(0, 683);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.UpdateButton.Size = new System.Drawing.Size(300, 60);
            this.UpdateButton.TabIndex = 21;
            this.UpdateButton.Text = "         Update";
            this.UpdateButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Visible = false;
            this.UpdateButton.Click += new System.EventHandler(this.Update_Click);
            // 
            // UpdateNotification
            // 
            this.UpdateNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UpdateNotification.BackColor = System.Drawing.Color.Transparent;
            this.UpdateNotification.Image = global::Contact_Tracking.Properties.Resources.circle_checkmark_green_36x36;
            this.UpdateNotification.Location = new System.Drawing.Point(25, 815);
            this.UpdateNotification.Name = "UpdateNotification";
            this.UpdateNotification.Size = new System.Drawing.Size(36, 36);
            this.UpdateNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UpdateNotification.TabIndex = 14;
            this.UpdateNotification.TabStop = false;
            // 
            // SideBar_Tracking
            // 
            this.SideBar_Tracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.SideBar_Tracking.FlatAppearance.BorderSize = 0;
            this.SideBar_Tracking.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.SideBar_Tracking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.SideBar_Tracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SideBar_Tracking.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.SideBar_Tracking.ForeColor = System.Drawing.Color.White;
            this.SideBar_Tracking.Image = global::Contact_Tracking.Properties.Resources.person_36x36;
            this.SideBar_Tracking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Tracking.Location = new System.Drawing.Point(0, 60);
            this.SideBar_Tracking.Margin = new System.Windows.Forms.Padding(0);
            this.SideBar_Tracking.Name = "SideBar_Tracking";
            this.SideBar_Tracking.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.SideBar_Tracking.Size = new System.Drawing.Size(300, 60);
            this.SideBar_Tracking.TabIndex = 17;
            this.SideBar_Tracking.Text = "         Erfassung";
            this.SideBar_Tracking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Tracking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SideBar_Tracking.UseVisualStyleBackColor = false;
            this.SideBar_Tracking.Click += new System.EventHandler(this.SideBar_Servers_Click);
            // 
            // SideBar_Settings
            // 
            this.SideBar_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SideBar_Settings.BackColor = System.Drawing.Color.Transparent;
            this.SideBar_Settings.FlatAppearance.BorderSize = 0;
            this.SideBar_Settings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.SideBar_Settings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.SideBar_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SideBar_Settings.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.SideBar_Settings.ForeColor = System.Drawing.Color.White;
            this.SideBar_Settings.Image = global::Contact_Tracking.Properties.Resources.cog_36x36;
            this.SideBar_Settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Settings.Location = new System.Drawing.Point(0, 743);
            this.SideBar_Settings.Margin = new System.Windows.Forms.Padding(0);
            this.SideBar_Settings.Name = "SideBar_Settings";
            this.SideBar_Settings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.SideBar_Settings.Size = new System.Drawing.Size(300, 60);
            this.SideBar_Settings.TabIndex = 16;
            this.SideBar_Settings.Text = "         Einstellungen";
            this.SideBar_Settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SideBar_Settings.UseVisualStyleBackColor = false;
            this.SideBar_Settings.Click += new System.EventHandler(this.SideBar_Settings_Click);
            // 
            // SideBar_Menu
            // 
            this.SideBar_Menu.BackColor = System.Drawing.Color.Transparent;
            this.SideBar_Menu.FlatAppearance.BorderSize = 0;
            this.SideBar_Menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.SideBar_Menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.SideBar_Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SideBar_Menu.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.SideBar_Menu.ForeColor = System.Drawing.Color.White;
            this.SideBar_Menu.Image = global::Contact_Tracking.Properties.Resources.menu_36x36;
            this.SideBar_Menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Menu.Location = new System.Drawing.Point(0, 0);
            this.SideBar_Menu.Margin = new System.Windows.Forms.Padding(0);
            this.SideBar_Menu.Name = "SideBar_Menu";
            this.SideBar_Menu.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.SideBar_Menu.Size = new System.Drawing.Size(300, 60);
            this.SideBar_Menu.TabIndex = 15;
            this.SideBar_Menu.Text = "         Menü";
            this.SideBar_Menu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideBar_Menu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SideBar_Menu.UseVisualStyleBackColor = false;
            this.SideBar_Menu.Click += new System.EventHandler(this.SideBar_Menu_Click);
            // 
            // CheckForUpdates
            // 
            this.CheckForUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckForUpdates.BackColor = System.Drawing.Color.Transparent;
            this.CheckForUpdates.FlatAppearance.BorderSize = 0;
            this.CheckForUpdates.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.CheckForUpdates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.CheckForUpdates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckForUpdates.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.CheckForUpdates.ForeColor = System.Drawing.Color.White;
            this.CheckForUpdates.Image = global::Contact_Tracking.Properties.Resources.refresh;
            this.CheckForUpdates.Location = new System.Drawing.Point(252, 815);
            this.CheckForUpdates.Margin = new System.Windows.Forms.Padding(0);
            this.CheckForUpdates.Name = "CheckForUpdates";
            this.CheckForUpdates.Size = new System.Drawing.Size(36, 36);
            this.CheckForUpdates.TabIndex = 23;
            this.CheckForUpdates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CheckForUpdates.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CheckForUpdates.UseVisualStyleBackColor = false;
            this.CheckForUpdates.Click += new System.EventHandler(this.CheckForUpdates_Click);
            // 
            // SideBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Controls.Add(this.Stats_Button);
            this.Controls.Add(this.SideBar_Create);
            this.Controls.Add(this.DownloadProgress);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.NewestLabel);
            this.Controls.Add(this.CurrentLabel);
            this.Controls.Add(this.NewestVersion);
            this.Controls.Add(this.CurrentVersion);
            this.Controls.Add(this.UpdateNotification);
            this.Controls.Add(this.SideBar_Tracking);
            this.Controls.Add(this.SideBar_Settings);
            this.Controls.Add(this.SideBar_Menu);
            this.Controls.Add(this.CheckForUpdates);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(300, 1000000000);
            this.MinimumSize = new System.Drawing.Size(85, 200);
            this.Name = "SideBar";
            this.Size = new System.Drawing.Size(300, 863);
            ((System.ComponentModel.ISupportInitialize)(this.UpdateNotification)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label CurrentVersion;
        public System.Windows.Forms.PictureBox UpdateNotification;
        private System.Windows.Forms.Button SideBar_Tracking;
        private System.Windows.Forms.Button SideBar_Settings;
        private System.Windows.Forms.Button SideBar_Menu;
        public System.Windows.Forms.Timer SideBarTimer;
        public System.Windows.Forms.Label NewestVersion;
        public System.Windows.Forms.Label CurrentLabel;
        public System.Windows.Forms.Label NewestLabel;
        public System.Windows.Forms.Button UpdateButton;
        public System.Windows.Forms.ProgressBar DownloadProgress;
        public System.Windows.Forms.Button CheckForUpdates;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button SideBar_Create;
        private System.Windows.Forms.Button Stats_Button;
    }
}
