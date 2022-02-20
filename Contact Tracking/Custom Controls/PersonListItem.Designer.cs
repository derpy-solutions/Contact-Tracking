
namespace Contact_Tracking.Custom_Controls
{
    partial class PersonListItem
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
            this.statusImage = new System.Windows.Forms.PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).BeginInit();
            this.SuspendLayout();
            // 
            // statusImage
            // 
            this.statusImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.statusImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusImage.Enabled = false;
            this.statusImage.Image = global::Contact_Tracking.Properties.Resources.circle_checkmark_green_16x16;
            this.statusImage.Location = new System.Drawing.Point(0, 0);
            this.statusImage.Margin = new System.Windows.Forms.Padding(2);
            this.statusImage.Name = "statusImage";
            this.statusImage.Size = new System.Drawing.Size(20, 20);
            this.statusImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.statusImage.TabIndex = 0;
            this.statusImage.TabStop = false;
            this.statusImage.Click += new System.EventHandler(this.PersonListItem_Click);
            this.statusImage.DoubleClick += new System.EventHandler(this.nameLabel_DoubleClick);
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.Location = new System.Drawing.Point(24, 0);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(343, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "label1";
            this.nameLabel.Click += new System.EventHandler(this.PersonListItem_Click);
            this.nameLabel.DoubleClick += new System.EventHandler(this.nameLabel_DoubleClick);
            this.nameLabel.Leave += new System.EventHandler(this.PersonListItem_Leave);
            // 
            // PersonListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.statusImage);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PersonListItem";
            this.Size = new System.Drawing.Size(367, 20);
            this.Click += new System.EventHandler(this.PersonListItem_Click);
            this.DoubleClick += new System.EventHandler(this.nameLabel_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.statusImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox statusImage;
        public System.Windows.Forms.Label nameLabel;
    }
}
