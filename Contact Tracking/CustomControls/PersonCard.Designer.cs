using System.Windows.Forms;
using System;

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
            this.Label_CoronaProof = new System.Windows.Forms.Label();
            this.PersonID = new System.Windows.Forms.Label();
            this.FirstName_TextBox = new System.Windows.Forms.TextBox();
            this.LastName_TextBox = new System.Windows.Forms.TextBox();
            this.Address_TextBox = new System.Windows.Forms.TextBox();
            this.Phone_TextBox = new System.Windows.Forms.TextBox();
            this.EMail_TextBox = new System.Windows.Forms.TextBox();
            this.Note_TextBox = new System.Windows.Forms.TextBox();
            this.Label_FirstName = new System.Windows.Forms.Label();
            this.Label_LastName = new System.Windows.Forms.Label();
            this.Label_DateOfBirth = new System.Windows.Forms.Label();
            this.Label_Tested = new System.Windows.Forms.Label();
            this.Label_Vaccinated = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.Discard = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Delete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Clear_DateOfBirth = new System.Windows.Forms.Button();
            this.DateOfBirth_Picker = new System.Windows.Forms.DateTimePicker();
            this.Label_Note = new System.Windows.Forms.Label();
            this.Label_EMail = new System.Windows.Forms.Label();
            this.Label_Phone = new System.Windows.Forms.Label();
            this.Label_Address = new System.Windows.Forms.Label();
            this.New_Button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.QR_Code = new System.Windows.Forms.PictureBox();
            this.CreateQR_Button = new System.Windows.Forms.Button();
            this.QRCode_Label = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Clear_Vaccinated = new System.Windows.Forms.Button();
            this.Clear_Tested = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Statistics_Label = new System.Windows.Forms.Label();
            this.Label_Gender = new System.Windows.Forms.Label();
            this.GenderCombo = new System.Windows.Forms.ComboBox();
            this.AgeCategory_Combo = new System.Windows.Forms.ComboBox();
            this.Migration_ChckBx = new Contact_Tracking.CustomControls.IconCheckbox();
            this.Label_AgeGroup = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.FlashingTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QR_Code)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tested_Picker
            // 
            this.Tested_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tested_Picker.CustomFormat = "dddd dd.MM.yyyy HH:mm";
            this.Tested_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Tested_Picker.Location = new System.Drawing.Point(139, 37);
            this.Tested_Picker.Name = "Tested_Picker";
            this.Tested_Picker.Size = new System.Drawing.Size(463, 26);
            this.Tested_Picker.TabIndex = 8;
            this.Tested_Picker.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Tested_Picker.ValueChanged += new System.EventHandler(this.Tested_Picker_ValueChanged);
            // 
            // Vaccinated_Picker
            // 
            this.Vaccinated_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vaccinated_Picker.CustomFormat = "dddd dd.MM.yyyy";
            this.Vaccinated_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Vaccinated_Picker.Location = new System.Drawing.Point(139, 72);
            this.Vaccinated_Picker.Name = "Vaccinated_Picker";
            this.Vaccinated_Picker.Size = new System.Drawing.Size(463, 26);
            this.Vaccinated_Picker.TabIndex = 9;
            this.Vaccinated_Picker.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.Vaccinated_Picker.ValueChanged += new System.EventHandler(this.Vaccinated_Picker_ValueChanged);
            // 
            // Label_CoronaProof
            // 
            this.Label_CoronaProof.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_CoronaProof.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.Label_CoronaProof.Location = new System.Drawing.Point(0, 0);
            this.Label_CoronaProof.Name = "Label_CoronaProof";
            this.Label_CoronaProof.Size = new System.Drawing.Size(647, 30);
            this.Label_CoronaProof.TabIndex = 18;
            this.Label_CoronaProof.Text = "Corona Nachweis";
            this.Label_CoronaProof.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PersonID
            // 
            this.PersonID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonID.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.PersonID.Location = new System.Drawing.Point(153, 5);
            this.PersonID.Name = "PersonID";
            this.PersonID.Size = new System.Drawing.Size(490, 42);
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
            this.FirstName_TextBox.Size = new System.Drawing.Size(493, 26);
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
            this.LastName_TextBox.Size = new System.Drawing.Size(493, 26);
            this.LastName_TextBox.TabIndex = 2;
            this.LastName_TextBox.TextChanged += new System.EventHandler(this.LastName_TextBox_TextChanged);
            // 
            // Address_TextBox
            // 
            this.Address_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Address_TextBox.Location = new System.Drawing.Point(150, 186);
            this.Address_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.Address_TextBox.Name = "Address_TextBox";
            this.Address_TextBox.Size = new System.Drawing.Size(493, 26);
            this.Address_TextBox.TabIndex = 4;
            this.Address_TextBox.TextChanged += new System.EventHandler(this.Address_TextBox_TextChanged);
            // 
            // Phone_TextBox
            // 
            this.Phone_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Phone_TextBox.Location = new System.Drawing.Point(150, 222);
            this.Phone_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.Phone_TextBox.Name = "Phone_TextBox";
            this.Phone_TextBox.Size = new System.Drawing.Size(493, 26);
            this.Phone_TextBox.TabIndex = 5;
            this.Phone_TextBox.TextChanged += new System.EventHandler(this.Phone_TextBox_TextChanged);
            // 
            // EMail_TextBox
            // 
            this.EMail_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EMail_TextBox.Location = new System.Drawing.Point(150, 258);
            this.EMail_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.EMail_TextBox.Name = "EMail_TextBox";
            this.EMail_TextBox.Size = new System.Drawing.Size(493, 26);
            this.EMail_TextBox.TabIndex = 6;
            this.EMail_TextBox.TextChanged += new System.EventHandler(this.EMail_TextBox_TextChanged);
            // 
            // Note_TextBox
            // 
            this.Note_TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Note_TextBox.Location = new System.Drawing.Point(150, 294);
            this.Note_TextBox.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.Note_TextBox.Multiline = true;
            this.Note_TextBox.Name = "Note_TextBox";
            this.Note_TextBox.Size = new System.Drawing.Size(493, 198);
            this.Note_TextBox.TabIndex = 7;
            this.Note_TextBox.TextChanged += new System.EventHandler(this.Note_TextBox_TextChanged);
            // 
            // Label_FirstName
            // 
            this.Label_FirstName.Location = new System.Drawing.Point(10, 75);
            this.Label_FirstName.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_FirstName.Name = "Label_FirstName";
            this.Label_FirstName.Size = new System.Drawing.Size(135, 26);
            this.Label_FirstName.TabIndex = 0;
            this.Label_FirstName.Text = "Vorname";
            this.Label_FirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_LastName
            // 
            this.Label_LastName.Location = new System.Drawing.Point(10, 111);
            this.Label_LastName.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_LastName.Name = "Label_LastName";
            this.Label_LastName.Size = new System.Drawing.Size(135, 26);
            this.Label_LastName.TabIndex = 25;
            this.Label_LastName.Text = "Nachname";
            this.Label_LastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_DateOfBirth
            // 
            this.Label_DateOfBirth.Location = new System.Drawing.Point(10, 150);
            this.Label_DateOfBirth.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_DateOfBirth.Name = "Label_DateOfBirth";
            this.Label_DateOfBirth.Size = new System.Drawing.Size(135, 26);
            this.Label_DateOfBirth.TabIndex = 26;
            this.Label_DateOfBirth.Text = "Geburtstag";
            this.Label_DateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Tested
            // 
            this.Label_Tested.Location = new System.Drawing.Point(4, 37);
            this.Label_Tested.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Label_Tested.Name = "Label_Tested";
            this.Label_Tested.Size = new System.Drawing.Size(133, 26);
            this.Label_Tested.TabIndex = 25;
            this.Label_Tested.Text = "Getestet";
            this.Label_Tested.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Vaccinated
            // 
            this.Label_Vaccinated.Location = new System.Drawing.Point(3, 72);
            this.Label_Vaccinated.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Label_Vaccinated.Name = "Label_Vaccinated";
            this.Label_Vaccinated.Size = new System.Drawing.Size(133, 26);
            this.Label_Vaccinated.TabIndex = 27;
            this.Label_Vaccinated.Text = "Impfung";
            this.Label_Vaccinated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1526, 707);
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
            this.tableLayoutPanel4.Location = new System.Drawing.Point(879, 660);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(644, 44);
            this.tableLayoutPanel4.TabIndex = 32;
            // 
            // Discard
            // 
            this.Discard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Discard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Discard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Discard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Discard.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.Discard.ForeColor = System.Drawing.Color.Transparent;
            this.Discard.Image = global::Contact_Tracking.Properties.Resources.reset;
            this.Discard.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Discard.Location = new System.Drawing.Point(3, 3);
            this.Discard.Name = "Discard";
            this.Discard.Size = new System.Drawing.Size(373, 38);
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
            this.Save.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.Save.ForeColor = System.Drawing.Color.Transparent;
            this.Save.Image = global::Contact_Tracking.Properties.Resources.save;
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Save.Location = new System.Drawing.Point(382, 3);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(259, 38);
            this.Save.TabIndex = 11;
            this.Save.Text = "  Speichern";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Save.UseVisualStyleBackColor = false;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Delete, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 660);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(642, 44);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // Delete
            // 
            this.Delete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.Delete.ForeColor = System.Drawing.Color.Transparent;
            this.Delete.Image = global::Contact_Tracking.Properties.Resources.delete;
            this.Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Delete.Location = new System.Drawing.Point(3, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(315, 38);
            this.Delete.TabIndex = 13;
            this.Delete.Text = "  Person Löschen";
            this.Delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Clear_DateOfBirth);
            this.panel1.Controls.Add(this.DateOfBirth_Picker);
            this.panel1.Controls.Add(this.Label_Note);
            this.panel1.Controls.Add(this.Label_EMail);
            this.panel1.Controls.Add(this.Label_Phone);
            this.panel1.Controls.Add(this.Label_Address);
            this.panel1.Controls.Add(this.PersonID);
            this.panel1.Controls.Add(this.Label_LastName);
            this.panel1.Controls.Add(this.Phone_TextBox);
            this.panel1.Controls.Add(this.EMail_TextBox);
            this.panel1.Controls.Add(this.Note_TextBox);
            this.panel1.Controls.Add(this.New_Button);
            this.panel1.Controls.Add(this.FirstName_TextBox);
            this.panel1.Controls.Add(this.Label_DateOfBirth);
            this.panel1.Controls.Add(this.Address_TextBox);
            this.panel1.Controls.Add(this.Label_FirstName);
            this.panel1.Controls.Add(this.LastName_TextBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 657);
            this.panel1.TabIndex = 0;
            // 
            // Clear_DateOfBirth
            // 
            this.Clear_DateOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_DateOfBirth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Clear_DateOfBirth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Clear_DateOfBirth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Clear_DateOfBirth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_DateOfBirth.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.Clear_DateOfBirth.ForeColor = System.Drawing.Color.Transparent;
            this.Clear_DateOfBirth.Image = global::Contact_Tracking.Properties.Resources.clear;
            this.Clear_DateOfBirth.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clear_DateOfBirth.Location = new System.Drawing.Point(606, 147);
            this.Clear_DateOfBirth.Name = "Clear_DateOfBirth";
            this.Clear_DateOfBirth.Size = new System.Drawing.Size(37, 28);
            this.Clear_DateOfBirth.TabIndex = 31;
            this.Clear_DateOfBirth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Clear_DateOfBirth.UseVisualStyleBackColor = false;
            this.Clear_DateOfBirth.Click += new System.EventHandler(this.Clear_DateOfBirth_Click);
            // 
            // DateOfBirth_Picker
            // 
            this.DateOfBirth_Picker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateOfBirth_Picker.CustomFormat = "dddd dd.MM.yyyy";
            this.DateOfBirth_Picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateOfBirth_Picker.Location = new System.Drawing.Point(150, 148);
            this.DateOfBirth_Picker.Name = "DateOfBirth_Picker";
            this.DateOfBirth_Picker.Size = new System.Drawing.Size(454, 26);
            this.DateOfBirth_Picker.TabIndex = 29;
            this.DateOfBirth_Picker.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DateOfBirth_Picker.ValueChanged += new System.EventHandler(this.DateOfBirth_Picker_ValueChanged);
            // 
            // Label_Note
            // 
            this.Label_Note.Location = new System.Drawing.Point(10, 294);
            this.Label_Note.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_Note.Name = "Label_Note";
            this.Label_Note.Size = new System.Drawing.Size(135, 26);
            this.Label_Note.TabIndex = 30;
            this.Label_Note.Text = "Notiz";
            this.Label_Note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_EMail
            // 
            this.Label_EMail.Location = new System.Drawing.Point(10, 258);
            this.Label_EMail.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_EMail.Name = "Label_EMail";
            this.Label_EMail.Size = new System.Drawing.Size(135, 26);
            this.Label_EMail.TabIndex = 29;
            this.Label_EMail.Text = "E-Mail";
            this.Label_EMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Phone
            // 
            this.Label_Phone.Location = new System.Drawing.Point(10, 222);
            this.Label_Phone.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_Phone.Name = "Label_Phone";
            this.Label_Phone.Size = new System.Drawing.Size(135, 26);
            this.Label_Phone.TabIndex = 28;
            this.Label_Phone.Text = "Telefon";
            this.Label_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Address
            // 
            this.Label_Address.Location = new System.Drawing.Point(10, 186);
            this.Label_Address.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_Address.Name = "Label_Address";
            this.Label_Address.Size = new System.Drawing.Size(135, 26);
            this.Label_Address.TabIndex = 27;
            this.Label_Address.Text = "Adresse";
            this.Label_Address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // New_Button
            // 
            this.New_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.New_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.New_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.New_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.New_Button.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(876, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 657);
            this.panel2.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.QR_Code);
            this.panel5.Controls.Add(this.CreateQR_Button);
            this.panel5.Controls.Add(this.QRCode_Label);
            this.panel5.Location = new System.Drawing.Point(0, 151);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(650, 340);
            this.panel5.TabIndex = 43;
            // 
            // QR_Code
            // 
            this.QR_Code.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QR_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.QR_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QR_Code.Location = new System.Drawing.Point(137, 33);
            this.QR_Code.Name = "QR_Code";
            this.QR_Code.Size = new System.Drawing.Size(507, 300);
            this.QR_Code.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QR_Code.TabIndex = 26;
            this.QR_Code.TabStop = false;
            // 
            // CreateQR_Button
            // 
            this.CreateQR_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CreateQR_Button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.CreateQR_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.CreateQR_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateQR_Button.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.CreateQR_Button.ForeColor = System.Drawing.Color.Transparent;
            this.CreateQR_Button.Image = global::Contact_Tracking.Properties.Resources.qr_code;
            this.CreateQR_Button.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateQR_Button.Location = new System.Drawing.Point(1, 33);
            this.CreateQR_Button.Name = "CreateQR_Button";
            this.CreateQR_Button.Size = new System.Drawing.Size(130, 35);
            this.CreateQR_Button.TabIndex = 19;
            this.CreateQR_Button.Text = "  Speichern";
            this.CreateQR_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateQR_Button.UseVisualStyleBackColor = false;
            this.CreateQR_Button.Click += new System.EventHandler(this.CreateQR_Button_Click);
            // 
            // QRCode_Label
            // 
            this.QRCode_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QRCode_Label.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.QRCode_Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QRCode_Label.Location = new System.Drawing.Point(0, 0);
            this.QRCode_Label.Name = "QRCode_Label";
            this.QRCode_Label.Size = new System.Drawing.Size(649, 30);
            this.QRCode_Label.TabIndex = 29;
            this.QRCode_Label.Text = "QR Code";
            this.QRCode_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Label_CoronaProof);
            this.panel4.Controls.Add(this.Tested_Picker);
            this.panel4.Controls.Add(this.Clear_Vaccinated);
            this.panel4.Controls.Add(this.Vaccinated_Picker);
            this.panel4.Controls.Add(this.Clear_Tested);
            this.panel4.Controls.Add(this.Label_Vaccinated);
            this.panel4.Controls.Add(this.Label_Tested);
            this.panel4.Location = new System.Drawing.Point(-1, 498);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(650, 110);
            this.panel4.TabIndex = 42;
            // 
            // Clear_Vaccinated
            // 
            this.Clear_Vaccinated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_Vaccinated.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Clear_Vaccinated.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Clear_Vaccinated.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Clear_Vaccinated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_Vaccinated.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.Clear_Vaccinated.ForeColor = System.Drawing.Color.Transparent;
            this.Clear_Vaccinated.Image = global::Contact_Tracking.Properties.Resources.clear;
            this.Clear_Vaccinated.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clear_Vaccinated.Location = new System.Drawing.Point(608, 70);
            this.Clear_Vaccinated.Name = "Clear_Vaccinated";
            this.Clear_Vaccinated.Size = new System.Drawing.Size(37, 28);
            this.Clear_Vaccinated.TabIndex = 40;
            this.Clear_Vaccinated.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Clear_Vaccinated.UseVisualStyleBackColor = false;
            this.Clear_Vaccinated.Click += new System.EventHandler(this.Clear_Vaccinated_Click);
            // 
            // Clear_Tested
            // 
            this.Clear_Tested.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_Tested.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Clear_Tested.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Clear_Tested.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Clear_Tested.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear_Tested.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.Clear_Tested.ForeColor = System.Drawing.Color.Transparent;
            this.Clear_Tested.Image = global::Contact_Tracking.Properties.Resources.clear;
            this.Clear_Tested.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clear_Tested.Location = new System.Drawing.Point(608, 36);
            this.Clear_Tested.Name = "Clear_Tested";
            this.Clear_Tested.Size = new System.Drawing.Size(37, 28);
            this.Clear_Tested.TabIndex = 39;
            this.Clear_Tested.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Clear_Tested.UseVisualStyleBackColor = false;
            this.Clear_Tested.Click += new System.EventHandler(this.Clear_Tested_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Statistics_Label);
            this.panel3.Controls.Add(this.Label_Gender);
            this.panel3.Controls.Add(this.GenderCombo);
            this.panel3.Controls.Add(this.AgeCategory_Combo);
            this.panel3.Controls.Add(this.Migration_ChckBx);
            this.panel3.Controls.Add(this.Label_AgeGroup);
            this.panel3.Location = new System.Drawing.Point(1, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 145);
            this.panel3.TabIndex = 41;
            // 
            // Statistics_Label
            // 
            this.Statistics_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Statistics_Label.Font = new System.Drawing.Font("Century Gothic", 18F);
            this.Statistics_Label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Statistics_Label.Location = new System.Drawing.Point(0, 0);
            this.Statistics_Label.Name = "Statistics_Label";
            this.Statistics_Label.Size = new System.Drawing.Size(636, 30);
            this.Statistics_Label.TabIndex = 30;
            this.Statistics_Label.Text = "Statistik";
            this.Statistics_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Gender
            // 
            this.Label_Gender.Location = new System.Drawing.Point(1, 73);
            this.Label_Gender.Margin = new System.Windows.Forms.Padding(10, 0, 5, 10);
            this.Label_Gender.Name = "Label_Gender";
            this.Label_Gender.Size = new System.Drawing.Size(135, 26);
            this.Label_Gender.TabIndex = 31;
            this.Label_Gender.Text = "Geschlecht";
            this.Label_Gender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GenderCombo
            // 
            this.GenderCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GenderCombo.FormattingEnabled = true;
            this.GenderCombo.Items.AddRange(new object[] {
            "divers",
            "männlich",
            "weiblich"});
            this.GenderCombo.Location = new System.Drawing.Point(137, 73);
            this.GenderCombo.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.GenderCombo.Name = "GenderCombo";
            this.GenderCombo.Size = new System.Drawing.Size(506, 28);
            this.GenderCombo.TabIndex = 32;
            this.GenderCombo.Text = "divers";
            this.GenderCombo.SelectedIndexChanged += new System.EventHandler(this.GenderCombo_SelectedIndexChanged);
            // 
            // AgeCategory_Combo
            // 
            this.AgeCategory_Combo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AgeCategory_Combo.FormattingEnabled = true;
            this.AgeCategory_Combo.Items.AddRange(new object[] {
            "6-13",
            "14-17",
            "18+"});
            this.AgeCategory_Combo.Location = new System.Drawing.Point(137, 34);
            this.AgeCategory_Combo.Margin = new System.Windows.Forms.Padding(0, 0, 5, 10);
            this.AgeCategory_Combo.Name = "AgeCategory_Combo";
            this.AgeCategory_Combo.Size = new System.Drawing.Size(506, 28);
            this.AgeCategory_Combo.TabIndex = 38;
            this.AgeCategory_Combo.Text = "6-13";
            this.AgeCategory_Combo.SelectedIndexChanged += new System.EventHandler(this.AgeCategory_Combo_SelectedIndexChanged);
            // 
            // Migration_ChckBx
            // 
            this.Migration_ChckBx._checked = false;
            this.Migration_ChckBx._Text = "Migrationshintergrund";
            this.Migration_ChckBx.BackColor = System.Drawing.Color.Transparent;
            this.Migration_ChckBx.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Migration_ChckBx.ForeColor = System.Drawing.Color.White;
            this.Migration_ChckBx.Location = new System.Drawing.Point(131, 107);
            this.Migration_ChckBx.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Migration_ChckBx.Name = "Migration_ChckBx";
            this.Migration_ChckBx.Size = new System.Drawing.Size(203, 30);
            this.Migration_ChckBx.TabIndex = 36;
            this.Migration_ChckBx._Clicked += new System.EventHandler(this.Migration_ChckBx__Clicked);
            // 
            // Label_AgeGroup
            // 
            this.Label_AgeGroup.Location = new System.Drawing.Point(1, 34);
            this.Label_AgeGroup.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.Label_AgeGroup.Name = "Label_AgeGroup";
            this.Label_AgeGroup.Size = new System.Drawing.Size(134, 26);
            this.Label_AgeGroup.TabIndex = 37;
            this.Label_AgeGroup.Text = "Altersgruppe";
            this.Label_AgeGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // FlashingTimer
            // 
            this.FlashingTimer.Interval = 25;
            this.FlashingTimer.Tick += new System.EventHandler(this.FlashingTimer_Tick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F);
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
            // PersonCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PersonCard";
            this.Size = new System.Drawing.Size(1526, 707);
            this.Load += new System.EventHandler(this.PersonCard_Load);
            this.VisibleChanged += new System.EventHandler(this.PersonCard_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QR_Code)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DateTimePicker Tested_Picker;
        public System.Windows.Forms.DateTimePicker Vaccinated_Picker;
        private System.Windows.Forms.Label Label_CoronaProof;
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
        private Label Label_FirstName;
        public Button New_Button;
        private Label Label_LastName;
        private Label Label_DateOfBirth;
        private Label Label_Tested;
        private Label Label_Vaccinated;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label Label_Note;
        private Label Label_EMail;
        private Label Label_Phone;
        private Label Label_Address;
        private Panel panel2;
        public PictureBox QR_Code;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
        public Button button1;
        private Label Label_Gender;
        public ComboBox GenderCombo;
        public DateTimePicker DateOfBirth_Picker;
        private Label QRCode_Label;
        private Timer FlashingTimer;
        private Label Statistics_Label;
        public CustomControls.IconCheckbox Migration_ChckBx;
        public ComboBox AgeCategory_Combo;
        private Label Label_AgeGroup;
        public Button Clear_DateOfBirth;
        public Button Clear_Vaccinated;
        public Button Clear_Tested;
        private Panel panel3;
        private Panel panel5;
        private Panel panel4;
    }
}
