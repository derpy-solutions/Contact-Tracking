using System.Windows.Forms;

namespace Contact_Tracking.Custom_Controls
{
    partial class PersonCard
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
            this.Tested_Picker = new System.Windows.Forms.DateTimePicker();
            this.Vaccinated_Picker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.Delete = new System.Windows.Forms.Button();
            this.Discard = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.CreateQR_Button = new System.Windows.Forms.Button();
            this.PersonID = new System.Windows.Forms.Label();
            this.FirstName_TextBox = new System.Windows.Forms.TextBox();
            this.LastName_TextBox = new System.Windows.Forms.TextBox();
            this.Address_TextBox = new System.Windows.Forms.TextBox();
            this.Phone_TextBox = new System.Windows.Forms.TextBox();
            this.EMail_TextBox = new System.Windows.Forms.TextBox();
            this.Note_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.New_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DateOfBirth_Picker = new System.Windows.Forms.DateTimePicker();
            this.SexCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.QR_Code = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.FlashingTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QR_Code)).BeginInit();
            this.SuspendLayout();
            // 
            // Tested_Picker
            // 
            this.Tested_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tested_Picker.CustomFormat = "dddd dd.MM.yyyy HH:mm";
            this.Tested_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Tested_Picker.Location = new System.Drawing.Point(144, 60);
            this.Tested_Picker.Name = "Tested_Picker";
            this.Tested_Picker.Size = new System.Drawing.Size(298, 26);
            this.Tested_Picker.TabIndex = 8;
            this.Tested_Picker.ValueChanged += new System.EventHandler(this.Tested_Picker_ValueChanged);
            // 
            // Vaccinated_Picker
            // 
            this.Vaccinated_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vaccinated_Picker.CustomFormat = "dddd dd.MM.yyyy";
            this.Vaccinated_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Vaccinated_Picker.Location = new System.Drawing.Point(144, 95);
            this.Vaccinated_Picker.Name = "Vaccinated_Picker";
            this.Vaccinated_Picker.Size = new System.Drawing.Size(298, 26);
            this.Vaccinated_Picker.TabIndex = 9;
            this.Vaccinated_Picker.ValueChanged += new System.EventHandler(this.Vaccinated_Picker_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(8, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(434, 30);
            this.label10.TabIndex = 18;
            this.label10.Text = "Corona Nachweis";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Delete.ForeColor = System.Drawing.Color.Transparent;
            this.Delete.Image = global::Contact_Tracking.Properties.Resources.delete;
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete.Location = new System.Drawing.Point(3, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(214, 38);
            this.Delete.TabIndex = 13;
            this.Delete.Text = "  Person Löschen";
            this.Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Discard
            // 
            this.Discard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Discard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Discard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Discard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Discard.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Discard.ForeColor = System.Drawing.Color.Transparent;
            this.Discard.Image = global::Contact_Tracking.Properties.Resources.reset;
            this.Discard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Discard.Location = new System.Drawing.Point(3, 3);
            this.Discard.Name = "Discard";
            this.Discard.Size = new System.Drawing.Size(254, 38);
            this.Discard.TabIndex = 12;
            this.Discard.Text = "  Änderungen Zurücksetzen";
            this.Discard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Discard.UseVisualStyleBackColor = false;
            this.Discard.Click += new System.EventHandler(this.Discard_Click);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Save.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Save.ForeColor = System.Drawing.Color.Transparent;
            this.Save.Image = global::Contact_Tracking.Properties.Resources.save;
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Save.Location = new System.Drawing.Point(263, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(176, 38);
            this.Save.TabIndex = 11;
            this.Save.Text = "  Speichern";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CreateQR_Button
            // 
            this.CreateQR_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CreateQR_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.CreateQR_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.CreateQR_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateQR_Button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CreateQR_Button.ForeColor = System.Drawing.Color.Transparent;
            this.CreateQR_Button.Image = global::Contact_Tracking.Properties.Resources.qr_code;
            this.CreateQR_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateQR_Button.Location = new System.Drawing.Point(8, 228);
            this.CreateQR_Button.Name = "CreateQR_Button";
            this.CreateQR_Button.Size = new System.Drawing.Size(130, 35);
            this.CreateQR_Button.TabIndex = 19;
            this.CreateQR_Button.Text = "  Speichern";
            this.CreateQR_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateQR_Button.UseVisualStyleBackColor = false;
            this.CreateQR_Button.Click += new System.EventHandler(this.CreateQR_Button_Click);
            // 
            // PersonID
            // 
            this.PersonID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonID.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PersonID.Location = new System.Drawing.Point(153, 5);
            this.PersonID.Name = "PersonID";
            this.PersonID.Size = new System.Drawing.Size(289, 42);
            this.PersonID.TabIndex = 22;
            this.PersonID.Text = "Persönliche ID: 0";
            this.PersonID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstName_TextBox
            // 
            this.FirstName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirstName_TextBox.Location = new System.Drawing.Point(150, 75);
            this.FirstName_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.FirstName_TextBox.Name = "FirstName_TextBox";
            this.FirstName_TextBox.Size = new System.Drawing.Size(292, 26);
            this.FirstName_TextBox.TabIndex = 1;
            this.FirstName_TextBox.TextChanged += new System.EventHandler(this.FirstName_TextBox_TextChanged);
            // 
            // LastName_TextBox
            // 
            this.LastName_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LastName_TextBox.Location = new System.Drawing.Point(150, 111);
            this.LastName_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.LastName_TextBox.Name = "LastName_TextBox";
            this.LastName_TextBox.Size = new System.Drawing.Size(292, 26);
            this.LastName_TextBox.TabIndex = 2;
            this.LastName_TextBox.TextChanged += new System.EventHandler(this.LastName_TextBox_TextChanged);
            // 
            // Address_TextBox
            // 
            this.Address_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Address_TextBox.Location = new System.Drawing.Point(150, 222);
            this.Address_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.Address_TextBox.Name = "Address_TextBox";
            this.Address_TextBox.Size = new System.Drawing.Size(292, 26);
            this.Address_TextBox.TabIndex = 4;
            this.Address_TextBox.TextChanged += new System.EventHandler(this.Address_TextBox_TextChanged);
            // 
            // Phone_TextBox
            // 
            this.Phone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Phone_TextBox.Location = new System.Drawing.Point(150, 258);
            this.Phone_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.Phone_TextBox.Name = "Phone_TextBox";
            this.Phone_TextBox.Size = new System.Drawing.Size(292, 26);
            this.Phone_TextBox.TabIndex = 5;
            this.Phone_TextBox.TextChanged += new System.EventHandler(this.Phone_TextBox_TextChanged);
            // 
            // EMail_TextBox
            // 
            this.EMail_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EMail_TextBox.Location = new System.Drawing.Point(150, 294);
            this.EMail_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.EMail_TextBox.Name = "EMail_TextBox";
            this.EMail_TextBox.Size = new System.Drawing.Size(292, 26);
            this.EMail_TextBox.TabIndex = 6;
            this.EMail_TextBox.TextChanged += new System.EventHandler(this.EMail_TextBox_TextChanged);
            // 
            // Note_TextBox
            // 
            this.Note_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Note_TextBox.Location = new System.Drawing.Point(150, 330);
            this.Note_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.Note_TextBox.Multiline = true;
            this.Note_TextBox.Name = "Note_TextBox";
            this.Note_TextBox.Size = new System.Drawing.Size(292, 198);
            this.Note_TextBox.TabIndex = 7;
            this.Note_TextBox.TextChanged += new System.EventHandler(this.Note_TextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vorname";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // New_Button
            // 
            this.New_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.New_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.New_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.New_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.New_Button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.New_Button.ForeColor = System.Drawing.Color.Transparent;
            this.New_Button.Image = global::Contact_Tracking.Properties.Resources.add;
            this.New_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.New_Button.Location = new System.Drawing.Point(0, 5);
            this.New_Button.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.New_Button.Name = "New_Button";
            this.New_Button.Size = new System.Drawing.Size(145, 42);
            this.New_Button.TabIndex = 21;
            this.New_Button.Text = "  Neu";
            this.New_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.New_Button.UseVisualStyleBackColor = false;
            this.New_Button.Click += new System.EventHandler(this.New_Button_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 26);
            this.label6.TabIndex = 25;
            this.label6.Text = "Nachname";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 186);
            this.label7.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 26);
            this.label7.TabIndex = 26;
            this.label7.Text = "Geburtstag";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 57);
            this.label11.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "Getestet";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 92);
            this.label12.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "Impfung";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1052, 673);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.95692F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.04308F));
            this.tableLayoutPanel4.Controls.Add(this.Discard, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.Save, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(607, 626);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(442, 44);
            this.tableLayoutPanel4.TabIndex = 32;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Delete, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 626);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(441, 44);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.DateOfBirth_Picker);
            this.panel1.Controls.Add(this.SexCombo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.PersonID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Phone_TextBox);
            this.panel1.Controls.Add(this.EMail_TextBox);
            this.panel1.Controls.Add(this.Note_TextBox);
            this.panel1.Controls.Add(this.New_Button);
            this.panel1.Controls.Add(this.FirstName_TextBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Address_TextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LastName_TextBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 623);
            this.panel1.TabIndex = 0;
            // 
            // DateOfBirth_Picker
            // 
            this.DateOfBirth_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateOfBirth_Picker.CustomFormat = "dddd dd.MM.yyyy";
            this.DateOfBirth_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfBirth_Picker.Location = new System.Drawing.Point(150, 184);
            this.DateOfBirth_Picker.Name = "DateOfBirth_Picker";
            this.DateOfBirth_Picker.Size = new System.Drawing.Size(292, 26);
            this.DateOfBirth_Picker.TabIndex = 29;
            this.DateOfBirth_Picker.ValueChanged += new System.EventHandler(this.DateOfBirth_Picker_ValueChanged);
            // 
            // SexCombo
            // 
            this.SexCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SexCombo.FormattingEnabled = true;
            this.SexCombo.Items.AddRange(new object[] {
            "divers",
            "männlich",
            "weiblich"});
            this.SexCombo.Location = new System.Drawing.Point(150, 147);
            this.SexCombo.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.SexCombo.Name = "SexCombo";
            this.SexCombo.Size = new System.Drawing.Size(292, 28);
            this.SexCombo.TabIndex = 32;
            this.SexCombo.Text = "divers";
            this.SexCombo.SelectedIndexChanged += new System.EventHandler(this.SexCombo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 147);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 26);
            this.label2.TabIndex = 31;
            this.label2.Text = "Geschlecht";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(10, 330);
            this.label15.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 26);
            this.label15.TabIndex = 30;
            this.label15.Text = "Notiz";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(10, 294);
            this.label14.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(135, 26);
            this.label14.TabIndex = 29;
            this.label14.Text = "E-Mail";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 258);
            this.label9.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 26);
            this.label9.TabIndex = 28;
            this.label9.Text = "Telefon";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(10, 222);
            this.label8.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 26);
            this.label8.TabIndex = 27;
            this.label8.Text = "Adresse";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.QR_Code);
            this.panel2.Controls.Add(this.CreateQR_Button);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.Vaccinated_Picker);
            this.panel2.Controls.Add(this.Tested_Picker);
            this.panel2.Location = new System.Drawing.Point(604, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 623);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(8, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 30);
            this.label3.TabIndex = 29;
            this.label3.Text = "QR Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // QR_Code
            // 
            this.QR_Code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QR_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.QR_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QR_Code.Location = new System.Drawing.Point(144, 228);
            this.QR_Code.Name = "QR_Code";
            this.QR_Code.Size = new System.Drawing.Size(298, 300);
            this.QR_Code.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QR_Code.TabIndex = 26;
            this.QR_Code.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::Contact_Tracking.Properties.Resources.delete;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(3, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 42);
            this.button1.TabIndex = 13;
            this.button1.Text = "  Person Löschen";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FlashingTimer
            // 
            this.FlashingTimer.Interval = 25;
            this.FlashingTimer.Tick += new System.EventHandler(this.FlashingTimer_Tick);
            // 
            // PersonCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PersonCard";
            this.Size = new System.Drawing.Size(1052, 673);
            this.Load += new System.EventHandler(this.PersonCard_Load);
            this.VisibleChanged += new System.EventHandler(this.PersonCard_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QR_Code)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DateTimePicker Tested_Picker;
        public System.Windows.Forms.DateTimePicker Vaccinated_Picker;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button Delete;
        public System.Windows.Forms.Button Discard;
        public System.Windows.Forms.Button Save;
        public Button CreateQR_Button;
        public Label PersonID;
        public TextBox FirstName_TextBox;
        public TextBox LastName_TextBox;
        public TextBox Address_TextBox;
        public TextBox Phone_TextBox;
        public TextBox EMail_TextBox;
        public TextBox Note_TextBox;
        private Label label1;
        public Button New_Button;
        private Label label6;
        private Label label7;
        private Label label11;
        private Label label12;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label15;
        private Label label14;
        private Label label9;
        private Label label8;
        private Panel panel2;
        public PictureBox QR_Code;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
        public Button button1;
        private Label label2;
        public ComboBox SexCombo;
        public DateTimePicker DateOfBirth_Picker;
        private Label label3;
        private Timer FlashingTimer;
    }
}
