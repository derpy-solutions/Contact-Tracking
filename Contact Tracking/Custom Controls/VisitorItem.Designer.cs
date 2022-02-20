
namespace Contact_Tracking.Custom_Controls
{
    partial class VisitorItem
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
            this.Time_Label = new System.Windows.Forms.Label();
            this.Name_Label = new System.Windows.Forms.Label();
            this.Favorites = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Time_Label
            // 
            this.Time_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Time_Label.Location = new System.Drawing.Point(0, 0);
            this.Time_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Time_Label.Name = "Time_Label";
            this.Time_Label.Size = new System.Drawing.Size(72, 22);
            this.Time_Label.TabIndex = 0;
            this.Time_Label.Text = "17:24:31";
            // 
            // Name_Label
            // 
            this.Name_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_Label.Location = new System.Drawing.Point(79, 0);
            this.Name_Label.Margin = new System.Windows.Forms.Padding(0);
            this.Name_Label.Name = "Name_Label";
            this.Name_Label.Size = new System.Drawing.Size(403, 22);
            this.Name_Label.TabIndex = 1;
            this.Name_Label.Text = "Nachname, Vorname";
            // 
            // Favorites
            // 
            this.Favorites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Favorites.BackColor = System.Drawing.Color.Transparent;
            this.Favorites.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Favorites.FlatAppearance.BorderSize = 0;
            this.Favorites.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.Favorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Favorites.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Favorites.ForeColor = System.Drawing.Color.Transparent;
            this.Favorites.Location = new System.Drawing.Point(485, 0);
            this.Favorites.Margin = new System.Windows.Forms.Padding(0);
            this.Favorites.Name = "Favorites";
            this.Favorites.Size = new System.Drawing.Size(22, 22);
            this.Favorites.TabIndex = 32;
            this.Favorites.Text = "X";
            this.Favorites.UseVisualStyleBackColor = false;
            this.Favorites.Click += new System.EventHandler(this.Favorites_Click);
            // 
            // VisitorItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Favorites);
            this.Controls.Add(this.Time_Label);
            this.Controls.Add(this.Name_Label);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "VisitorItem";
            this.Size = new System.Drawing.Size(518, 22);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label Time_Label;
        public System.Windows.Forms.Label Name_Label;
        public System.Windows.Forms.Button Favorites;
    }
}
