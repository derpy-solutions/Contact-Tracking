
namespace Contact_Tracking.Custom_Controls
{
    partial class QRCodeReader
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
            this.Camera = new System.Windows.Forms.PictureBox();
            this.QR_Text = new System.Windows.Forms.TextBox();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.QRTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Camera)).BeginInit();
            this.SuspendLayout();
            // 
            // Camera
            // 
            this.Camera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Camera.Location = new System.Drawing.Point(4, 40);
            this.Camera.Margin = new System.Windows.Forms.Padding(4);
            this.Camera.Name = "Camera";
            this.Camera.Size = new System.Drawing.Size(300, 298);
            this.Camera.TabIndex = 17;
            this.Camera.TabStop = false;
            // 
            // QR_Text
            // 
            this.QR_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.QR_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QR_Text.ForeColor = System.Drawing.Color.White;
            this.QR_Text.Location = new System.Drawing.Point(312, 4);
            this.QR_Text.Margin = new System.Windows.Forms.Padding(4);
            this.QR_Text.Multiline = true;
            this.QR_Text.Name = "QR_Text";
            this.QR_Text.Size = new System.Drawing.Size(349, 336);
            this.QR_Text.TabIndex = 18;
            this.QR_Text.Visible = false;
            // 
            // cboDevice
            // 
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Location = new System.Drawing.Point(4, 4);
            this.cboDevice.Margin = new System.Windows.Forms.Padding(4);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(300, 28);
            this.cboDevice.TabIndex = 19;
            // 
            // QRTimer
            // 
            this.QRTimer.Interval = 25;
            this.QRTimer.Tick += new System.EventHandler(this.QRTimer_Tick);
            // 
            // QRCodeReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cboDevice);
            this.Controls.Add(this.Camera);
            this.Controls.Add(this.QR_Text);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QRCodeReader";
            this.Size = new System.Drawing.Size(309, 342);
            this.Load += new System.EventHandler(this.QRCodeReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Camera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox Camera;
        private System.Windows.Forms.TextBox QR_Text;
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.Timer QRTimer;
    }
}
