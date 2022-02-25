
namespace Contact_Tracking.Custom_Controls
{
    partial class RestartPopUp
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
            this.NoRestart = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.Content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NoRestart
            // 
            this.NoRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NoRestart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NoRestart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.NoRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NoRestart.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.NoRestart.ForeColor = System.Drawing.Color.Transparent;
            this.NoRestart.Image = global::Contact_Tracking.Properties.Resources.stop;
            this.NoRestart.Location = new System.Drawing.Point(3, 164);
            this.NoRestart.Name = "NoRestart";
            this.NoRestart.Size = new System.Drawing.Size(253, 34);
            this.NoRestart.TabIndex = 23;
            this.NoRestart.Text = "      Nicht Neustarten";
            this.NoRestart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NoRestart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NoRestart.UseVisualStyleBackColor = false;
            this.NoRestart.Click += new System.EventHandler(this.NoRestart_Click);
            // 
            // Restart
            // 
            this.Restart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Restart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Restart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Restart.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.Restart.ForeColor = System.Drawing.Color.Transparent;
            this.Restart.Image = global::Contact_Tracking.Properties.Resources.checkmark;
            this.Restart.Location = new System.Drawing.Point(261, 164);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(253, 34);
            this.Restart.TabIndex = 24;
            this.Restart.Text = "     Neustarten";
            this.Restart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Restart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content.ForeColor = System.Drawing.Color.White;
            this.Content.Location = new System.Drawing.Point(10, 10);
            this.Content.Margin = new System.Windows.Forms.Padding(10);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(497, 141);
            this.Content.TabIndex = 25;
            this.Content.Text = "Damit die eben installierten Schriftarten genutzt werden können, muss das Program" +
    "m neugestartet werden. \r\n\r\nJetzt neustarten?";
            this.Content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RestartPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.Content);
            this.Controls.Add(this.Restart);
            this.Controls.Add(this.NoRestart);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RestartPopUp";
            this.Size = new System.Drawing.Size(517, 201);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button NoRestart;
        public System.Windows.Forms.Button Restart;
        public System.Windows.Forms.Label Content;
    }
}
