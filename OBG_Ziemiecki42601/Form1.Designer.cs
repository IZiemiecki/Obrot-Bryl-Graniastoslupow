namespace OBG_Ziemiecki42601
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.iz_PictureBox = new System.Windows.Forms.PictureBox();
            this.iz_AddNew = new System.Windows.Forms.Button();
            this.iz_BtnLeft = new System.Windows.Forms.Button();
            this.iz_BtnRight = new System.Windows.Forms.Button();
            this.iz_Timer = new System.Windows.Forms.Timer(this.components);
            this.iz_PokazSlajdow = new System.Windows.Forms.Timer(this.components);
            this.iz_btnTurnOn = new System.Windows.Forms.Button();
            this.iz_rdbAuto = new System.Windows.Forms.RadioButton();
            this.iz_gbSlajd = new System.Windows.Forms.GroupBox();
            this.iz_rbEvent = new System.Windows.Forms.RadioButton();
            this.iz_txtSlajd = new System.Windows.Forms.TextBox();
            this.iz_EP = new System.Windows.Forms.ErrorProvider(this.components);
            this.iz_btnNext = new System.Windows.Forms.Button();
            this.iz_btnPrev = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.iz_btnRoll = new System.Windows.Forms.Button();
            this.iz_btnRemoveFirst = new System.Windows.Forms.Button();
            this.iz_btnRemoveLast = new System.Windows.Forms.Button();
            this.iz_BtnRemoveExac = new System.Windows.Forms.Button();
            this.iz_nudNumber = new System.Windows.Forms.NumericUpDown();
            this.iz_BtnRollPosition = new System.Windows.Forms.Button();
            this.iz_cmbSolidsList = new System.Windows.Forms.ComboBox();
            this.iz_trb1 = new System.Windows.Forms.TrackBar();
            this.iz_trb2 = new System.Windows.Forms.TrackBar();
            this.iz_lbl1 = new System.Windows.Forms.Label();
            this.iz_lbl2 = new System.Windows.Forms.Label();
            this.iz_lbl3 = new System.Windows.Forms.Label();
            this.iz_trb3 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.iz_PictureBox)).BeginInit();
            this.iz_gbSlajd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iz_EP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_nudNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trb3)).BeginInit();
            this.SuspendLayout();
            // 
            // iz_PictureBox
            // 
            this.iz_PictureBox.BackColor = System.Drawing.Color.White;
            this.iz_PictureBox.Location = new System.Drawing.Point(114, 41);
            this.iz_PictureBox.Name = "iz_PictureBox";
            this.iz_PictureBox.Size = new System.Drawing.Size(748, 439);
            this.iz_PictureBox.TabIndex = 0;
            this.iz_PictureBox.TabStop = false;
            // 
            // iz_AddNew
            // 
            this.iz_AddNew.Location = new System.Drawing.Point(12, 314);
            this.iz_AddNew.Name = "iz_AddNew";
            this.iz_AddNew.Size = new System.Drawing.Size(96, 23);
            this.iz_AddNew.TabIndex = 1;
            this.iz_AddNew.Text = "Dodaj";
            this.iz_AddNew.UseVisualStyleBackColor = true;
            this.iz_AddNew.Click += new System.EventHandler(this.iz_AddNew_Click);
            // 
            // iz_BtnLeft
            // 
            this.iz_BtnLeft.Location = new System.Drawing.Point(12, 343);
            this.iz_BtnLeft.Name = "iz_BtnLeft";
            this.iz_BtnLeft.Size = new System.Drawing.Size(96, 23);
            this.iz_BtnLeft.TabIndex = 2;
            this.iz_BtnLeft.Text = "W lewo";
            this.iz_BtnLeft.UseVisualStyleBackColor = true;
            this.iz_BtnLeft.Click += new System.EventHandler(this.iz_BtnLeft_Click);
            // 
            // iz_BtnRight
            // 
            this.iz_BtnRight.Location = new System.Drawing.Point(12, 372);
            this.iz_BtnRight.Name = "iz_BtnRight";
            this.iz_BtnRight.Size = new System.Drawing.Size(96, 23);
            this.iz_BtnRight.TabIndex = 3;
            this.iz_BtnRight.Text = "W prawo";
            this.iz_BtnRight.UseVisualStyleBackColor = true;
            this.iz_BtnRight.Click += new System.EventHandler(this.iz_BtnRight_Click);
            // 
            // iz_Timer
            // 
            this.iz_Timer.Enabled = true;
            this.iz_Timer.Tick += new System.EventHandler(this.iz_Timer_Tick);
            // 
            // iz_PokazSlajdow
            // 
            this.iz_PokazSlajdow.Interval = 1000;
            this.iz_PokazSlajdow.Tag = "0";
            this.iz_PokazSlajdow.Tick += new System.EventHandler(this.iz_PokazSlajdow_Tick);
            // 
            // iz_btnTurnOn
            // 
            this.iz_btnTurnOn.Location = new System.Drawing.Point(868, 146);
            this.iz_btnTurnOn.Name = "iz_btnTurnOn";
            this.iz_btnTurnOn.Size = new System.Drawing.Size(138, 23);
            this.iz_btnTurnOn.TabIndex = 4;
            this.iz_btnTurnOn.Text = "Włącz pokaz slajdów";
            this.iz_btnTurnOn.UseVisualStyleBackColor = true;
            this.iz_btnTurnOn.Click += new System.EventHandler(this.iz_btnTurnOn_Click);
            // 
            // iz_rdbAuto
            // 
            this.iz_rdbAuto.AutoSize = true;
            this.iz_rdbAuto.Checked = true;
            this.iz_rdbAuto.Location = new System.Drawing.Point(6, 19);
            this.iz_rdbAuto.Name = "iz_rdbAuto";
            this.iz_rdbAuto.Size = new System.Drawing.Size(91, 17);
            this.iz_rdbAuto.TabIndex = 5;
            this.iz_rdbAuto.TabStop = true;
            this.iz_rdbAuto.Text = "Automatyczny";
            this.iz_rdbAuto.UseVisualStyleBackColor = true;
            // 
            // iz_gbSlajd
            // 
            this.iz_gbSlajd.Controls.Add(this.iz_rbEvent);
            this.iz_gbSlajd.Controls.Add(this.iz_rdbAuto);
            this.iz_gbSlajd.Location = new System.Drawing.Point(868, 75);
            this.iz_gbSlajd.Name = "iz_gbSlajd";
            this.iz_gbSlajd.Size = new System.Drawing.Size(138, 65);
            this.iz_gbSlajd.TabIndex = 6;
            this.iz_gbSlajd.TabStop = false;
            this.iz_gbSlajd.Text = "Tryb pokazu slajdów";
            // 
            // iz_rbEvent
            // 
            this.iz_rbEvent.AutoSize = true;
            this.iz_rbEvent.Location = new System.Drawing.Point(6, 42);
            this.iz_rbEvent.Name = "iz_rbEvent";
            this.iz_rbEvent.Size = new System.Drawing.Size(85, 17);
            this.iz_rbEvent.TabIndex = 6;
            this.iz_rbEvent.Text = "Zdarzeniowy";
            this.iz_rbEvent.UseVisualStyleBackColor = true;
            // 
            // iz_txtSlajd
            // 
            this.iz_txtSlajd.Location = new System.Drawing.Point(892, 175);
            this.iz_txtSlajd.Name = "iz_txtSlajd";
            this.iz_txtSlajd.Size = new System.Drawing.Size(100, 20);
            this.iz_txtSlajd.TabIndex = 7;
            this.iz_txtSlajd.TextChanged += new System.EventHandler(this.iz_txtSlajd_TextChanged);
            // 
            // iz_EP
            // 
            this.iz_EP.ContainerControl = this;
            // 
            // iz_btnNext
            // 
            this.iz_btnNext.Location = new System.Drawing.Point(868, 201);
            this.iz_btnNext.Name = "iz_btnNext";
            this.iz_btnNext.Size = new System.Drawing.Size(68, 23);
            this.iz_btnNext.TabIndex = 8;
            this.iz_btnNext.Text = "Następny";
            this.iz_btnNext.UseVisualStyleBackColor = true;
            this.iz_btnNext.Click += new System.EventHandler(this.iz_btnNext_Click);
            // 
            // iz_btnPrev
            // 
            this.iz_btnPrev.Location = new System.Drawing.Point(942, 201);
            this.iz_btnPrev.Name = "iz_btnPrev";
            this.iz_btnPrev.Size = new System.Drawing.Size(64, 23);
            this.iz_btnPrev.TabIndex = 9;
            this.iz_btnPrev.Text = "Poprzedni";
            this.iz_btnPrev.UseVisualStyleBackColor = true;
            this.iz_btnPrev.Click += new System.EventHandler(this.iz_btnPrev_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(874, 230);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Wyłącz pokaz slajdów";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iz_btnRoll
            // 
            this.iz_btnRoll.Location = new System.Drawing.Point(12, 401);
            this.iz_btnRoll.Name = "iz_btnRoll";
            this.iz_btnRoll.Size = new System.Drawing.Size(96, 50);
            this.iz_btnRoll.TabIndex = 11;
            this.iz_btnRoll.Text = "Wylosuj właściwości graficzne";
            this.iz_btnRoll.UseVisualStyleBackColor = true;
            this.iz_btnRoll.Click += new System.EventHandler(this.iz_btnRoll_Click);
            // 
            // iz_btnRemoveFirst
            // 
            this.iz_btnRemoveFirst.Location = new System.Drawing.Point(114, 12);
            this.iz_btnRemoveFirst.Name = "iz_btnRemoveFirst";
            this.iz_btnRemoveFirst.Size = new System.Drawing.Size(144, 23);
            this.iz_btnRemoveFirst.TabIndex = 12;
            this.iz_btnRemoveFirst.Text = "Usuń pierwszą figurę";
            this.iz_btnRemoveFirst.UseVisualStyleBackColor = true;
            this.iz_btnRemoveFirst.Click += new System.EventHandler(this.iz_btnRemoveFirst_Click);
            // 
            // iz_btnRemoveLast
            // 
            this.iz_btnRemoveLast.Location = new System.Drawing.Point(264, 12);
            this.iz_btnRemoveLast.Name = "iz_btnRemoveLast";
            this.iz_btnRemoveLast.Size = new System.Drawing.Size(144, 23);
            this.iz_btnRemoveLast.TabIndex = 13;
            this.iz_btnRemoveLast.Text = "Usuń ostatnią figurę";
            this.iz_btnRemoveLast.UseVisualStyleBackColor = true;
            this.iz_btnRemoveLast.Click += new System.EventHandler(this.iz_btnRemoveLast_Click);
            // 
            // iz_BtnRemoveExac
            // 
            this.iz_BtnRemoveExac.Location = new System.Drawing.Point(414, 12);
            this.iz_BtnRemoveExac.Name = "iz_BtnRemoveExac";
            this.iz_BtnRemoveExac.Size = new System.Drawing.Size(174, 23);
            this.iz_BtnRemoveExac.TabIndex = 14;
            this.iz_BtnRemoveExac.Text = "Usuń figurę o podanym numerze:";
            this.iz_BtnRemoveExac.UseVisualStyleBackColor = true;
            this.iz_BtnRemoveExac.Click += new System.EventHandler(this.iz_BtnRemoveExac_Click);
            // 
            // iz_nudNumber
            // 
            this.iz_nudNumber.Location = new System.Drawing.Point(594, 15);
            this.iz_nudNumber.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.iz_nudNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iz_nudNumber.Name = "iz_nudNumber";
            this.iz_nudNumber.Size = new System.Drawing.Size(78, 20);
            this.iz_nudNumber.TabIndex = 15;
            this.iz_nudNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.iz_nudNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // iz_BtnRollPosition
            // 
            this.iz_BtnRollPosition.Location = new System.Drawing.Point(12, 457);
            this.iz_BtnRollPosition.Name = "iz_BtnRollPosition";
            this.iz_BtnRollPosition.Size = new System.Drawing.Size(96, 23);
            this.iz_BtnRollPosition.TabIndex = 16;
            this.iz_BtnRollPosition.Text = "Losuj położenie";
            this.iz_BtnRollPosition.UseVisualStyleBackColor = true;
            this.iz_BtnRollPosition.Click += new System.EventHandler(this.iz_BtnRollPosition_Click);
            // 
            // iz_cmbSolidsList
            // 
            this.iz_cmbSolidsList.FormattingEnabled = true;
            this.iz_cmbSolidsList.Items.AddRange(new object[] {
            "Ostrosłup",
            "Graniastosłup",
            "Kula",
            "Walec"});
            this.iz_cmbSolidsList.Location = new System.Drawing.Point(12, 12);
            this.iz_cmbSolidsList.Name = "iz_cmbSolidsList";
            this.iz_cmbSolidsList.Size = new System.Drawing.Size(96, 21);
            this.iz_cmbSolidsList.TabIndex = 17;
            this.iz_cmbSolidsList.SelectedIndexChanged += new System.EventHandler(this.iz_cmbSolidsList_SelectedIndexChanged);
            // 
            // iz_trb1
            // 
            this.iz_trb1.AutoSize = false;
            this.iz_trb1.Enabled = false;
            this.iz_trb1.Location = new System.Drawing.Point(12, 62);
            this.iz_trb1.Maximum = 20;
            this.iz_trb1.Minimum = 1;
            this.iz_trb1.Name = "iz_trb1";
            this.iz_trb1.Size = new System.Drawing.Size(96, 24);
            this.iz_trb1.TabIndex = 18;
            this.iz_trb1.Value = 1;
            this.iz_trb1.Visible = false;
            // 
            // iz_trb2
            // 
            this.iz_trb2.AutoSize = false;
            this.iz_trb2.Enabled = false;
            this.iz_trb2.Location = new System.Drawing.Point(12, 120);
            this.iz_trb2.Maximum = 20;
            this.iz_trb2.Minimum = 1;
            this.iz_trb2.Name = "iz_trb2";
            this.iz_trb2.Size = new System.Drawing.Size(96, 24);
            this.iz_trb2.TabIndex = 19;
            this.iz_trb2.Value = 1;
            this.iz_trb2.Visible = false;
            // 
            // iz_lbl1
            // 
            this.iz_lbl1.Enabled = false;
            this.iz_lbl1.Location = new System.Drawing.Point(12, 36);
            this.iz_lbl1.Name = "iz_lbl1";
            this.iz_lbl1.Size = new System.Drawing.Size(96, 23);
            this.iz_lbl1.TabIndex = 20;
            this.iz_lbl1.Text = "label1";
            this.iz_lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iz_lbl1.Visible = false;
            // 
            // iz_lbl2
            // 
            this.iz_lbl2.Enabled = false;
            this.iz_lbl2.Location = new System.Drawing.Point(12, 94);
            this.iz_lbl2.Name = "iz_lbl2";
            this.iz_lbl2.Size = new System.Drawing.Size(96, 23);
            this.iz_lbl2.TabIndex = 21;
            this.iz_lbl2.Text = "label2";
            this.iz_lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iz_lbl2.Visible = false;
            // 
            // iz_lbl3
            // 
            this.iz_lbl3.Enabled = false;
            this.iz_lbl3.Location = new System.Drawing.Point(12, 147);
            this.iz_lbl3.Name = "iz_lbl3";
            this.iz_lbl3.Size = new System.Drawing.Size(96, 23);
            this.iz_lbl3.TabIndex = 22;
            this.iz_lbl3.Text = "label3";
            this.iz_lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.iz_lbl3.Visible = false;
            // 
            // iz_trb3
            // 
            this.iz_trb3.AutoSize = false;
            this.iz_trb3.Enabled = false;
            this.iz_trb3.Location = new System.Drawing.Point(12, 173);
            this.iz_trb3.Maximum = 20;
            this.iz_trb3.Minimum = 1;
            this.iz_trb3.Name = "iz_trb3";
            this.iz_trb3.Size = new System.Drawing.Size(96, 24);
            this.iz_trb3.TabIndex = 23;
            this.iz_trb3.Value = 1;
            this.iz_trb3.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 492);
            this.Controls.Add(this.iz_trb3);
            this.Controls.Add(this.iz_lbl3);
            this.Controls.Add(this.iz_lbl2);
            this.Controls.Add(this.iz_lbl1);
            this.Controls.Add(this.iz_trb2);
            this.Controls.Add(this.iz_trb1);
            this.Controls.Add(this.iz_cmbSolidsList);
            this.Controls.Add(this.iz_BtnRollPosition);
            this.Controls.Add(this.iz_nudNumber);
            this.Controls.Add(this.iz_BtnRemoveExac);
            this.Controls.Add(this.iz_btnRemoveLast);
            this.Controls.Add(this.iz_btnRemoveFirst);
            this.Controls.Add(this.iz_btnRoll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iz_btnPrev);
            this.Controls.Add(this.iz_btnNext);
            this.Controls.Add(this.iz_txtSlajd);
            this.Controls.Add(this.iz_gbSlajd);
            this.Controls.Add(this.iz_btnTurnOn);
            this.Controls.Add(this.iz_BtnRight);
            this.Controls.Add(this.iz_BtnLeft);
            this.Controls.Add(this.iz_AddNew);
            this.Controls.Add(this.iz_PictureBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Wizualizacja Brył";
            ((System.ComponentModel.ISupportInitialize)(this.iz_PictureBox)).EndInit();
            this.iz_gbSlajd.ResumeLayout(false);
            this.iz_gbSlajd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iz_EP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_nudNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iz_trb3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox iz_PictureBox;
        private System.Windows.Forms.Button iz_AddNew;
        private System.Windows.Forms.Button iz_BtnLeft;
        private System.Windows.Forms.Button iz_BtnRight;
        private System.Windows.Forms.Timer iz_Timer;
        private System.Windows.Forms.Timer iz_PokazSlajdow;
        private System.Windows.Forms.Button iz_btnTurnOn;
        private System.Windows.Forms.RadioButton iz_rdbAuto;
        private System.Windows.Forms.GroupBox iz_gbSlajd;
        private System.Windows.Forms.RadioButton iz_rbEvent;
        private System.Windows.Forms.TextBox iz_txtSlajd;
        private System.Windows.Forms.ErrorProvider iz_EP;
        private System.Windows.Forms.Button iz_btnPrev;
        private System.Windows.Forms.Button iz_btnNext;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button iz_btnRoll;
        private System.Windows.Forms.NumericUpDown iz_nudNumber;
        private System.Windows.Forms.Button iz_BtnRemoveExac;
        private System.Windows.Forms.Button iz_btnRemoveLast;
        private System.Windows.Forms.Button iz_btnRemoveFirst;
        private System.Windows.Forms.Button iz_BtnRollPosition;
        private System.Windows.Forms.ComboBox iz_cmbSolidsList;
        private System.Windows.Forms.TrackBar iz_trb3;
        private System.Windows.Forms.Label iz_lbl3;
        private System.Windows.Forms.Label iz_lbl2;
        private System.Windows.Forms.Label iz_lbl1;
        private System.Windows.Forms.TrackBar iz_trb2;
        private System.Windows.Forms.TrackBar iz_trb1;



    }
}

