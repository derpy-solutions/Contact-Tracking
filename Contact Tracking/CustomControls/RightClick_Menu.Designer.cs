
namespace Contact_Tracking.Custom_Controls
{
    partial class RightClick_Menu
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
            this.Edit = new System.Windows.Forms.Button();
            this.AddVisit = new System.Windows.Forms.Button();
            this.CreateQR = new System.Windows.Forms.Button();
            this.personName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Edit
            // 
            this.Edit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Edit.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Edit.Location = new System.Drawing.Point(5, 32);
            this.Edit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(204, 30);
            this.Edit.TabIndex = 0;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // AddVisit
            // 
            this.AddVisit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddVisit.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.AddVisit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddVisit.Location = new System.Drawing.Point(5, 70);
            this.AddVisit.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.AddVisit.Name = "AddVisit";
            this.AddVisit.Size = new System.Drawing.Size(204, 30);
            this.AddVisit.TabIndex = 1;
            this.AddVisit.Text = "Add Visit";
            this.AddVisit.UseVisualStyleBackColor = true;
            this.AddVisit.Click += new System.EventHandler(this.AddVisit_Click);
            // 
            // CreateQR
            // 
            this.CreateQR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateQR.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.CreateQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateQR.Location = new System.Drawing.Point(5, 108);
            this.CreateQR.Margin = new System.Windows.Forms.Padding(5, 5, 5, 3);
            this.CreateQR.Name = "CreateQR";
            this.CreateQR.Size = new System.Drawing.Size(204, 30);
            this.CreateQR.TabIndex = 2;
            this.CreateQR.Text = "Create QR";
            this.CreateQR.UseVisualStyleBackColor = true;
            this.CreateQR.Click += new System.EventHandler(this.CreateQR_Click);
            // 
            // personName
            // 
            this.personName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.personName.Location = new System.Drawing.Point(3, 0);
            this.personName.Name = "personName";
            this.personName.Size = new System.Drawing.Size(210, 27);
            this.personName.TabIndex = 3;
            this.personName.Text = "label1";
            this.personName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RightClick_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.personName);
            this.Controls.Add(this.CreateQR);
            this.Controls.Add(this.AddVisit);
            this.Controls.Add(this.Edit);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RightClick_Menu";
            this.Size = new System.Drawing.Size(216, 145);
            this.Leave += new System.EventHandler(this.RightClick_Menu_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button AddVisit;
        private System.Windows.Forms.Button CreateQR;
        public System.Windows.Forms.Label personName;
    }
}
