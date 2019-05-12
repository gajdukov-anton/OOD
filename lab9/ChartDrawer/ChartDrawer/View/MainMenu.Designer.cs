namespace ChartDrawer.View
{
    partial class MainMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.HarmonicProperties = new System.Windows.Forms.GroupBox();
            this.phaseLabel = new System.Windows.Forms.Label();
            this.phaseTextBox = new System.Windows.Forms.TextBox();
            this.frequencyLabel = new System.Windows.Forms.Label();
            this.frequencyTextBox = new System.Windows.Forms.TextBox();
            this.cosRadioButton = new System.Windows.Forms.RadioButton();
            this.sinRadioButton = new System.Windows.Forms.RadioButton();
            this.amplitudeLabel = new System.Windows.Forms.Label();
            this.amplitudeTextBox = new System.Windows.Forms.TextBox();
            this.AddNewHarmonicButton = new System.Windows.Forms.Button();
            this.deleteHarmonicButton = new System.Windows.Forms.Button();
            this.Harmonics = new System.Windows.Forms.GroupBox();
            this.harmonicList = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.HarmonicProperties.SuspendLayout();
            this.Harmonics.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HarmonicProperties
            // 
            this.HarmonicProperties.AutoSize = true;
            this.HarmonicProperties.Controls.Add(this.phaseLabel);
            this.HarmonicProperties.Controls.Add(this.phaseTextBox);
            this.HarmonicProperties.Controls.Add(this.frequencyLabel);
            this.HarmonicProperties.Controls.Add(this.frequencyTextBox);
            this.HarmonicProperties.Controls.Add(this.cosRadioButton);
            this.HarmonicProperties.Controls.Add(this.sinRadioButton);
            this.HarmonicProperties.Controls.Add(this.amplitudeLabel);
            this.HarmonicProperties.Controls.Add(this.amplitudeTextBox);
            this.HarmonicProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HarmonicProperties.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HarmonicProperties.Location = new System.Drawing.Point(332, 12);
            this.HarmonicProperties.Margin = new System.Windows.Forms.Padding(0);
            this.HarmonicProperties.Name = "HarmonicProperties";
            this.HarmonicProperties.Padding = new System.Windows.Forms.Padding(0);
            this.HarmonicProperties.Size = new System.Drawing.Size(291, 232);
            this.HarmonicProperties.TabIndex = 0;
            this.HarmonicProperties.TabStop = false;
            this.HarmonicProperties.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // phaseLabel
            // 
            this.phaseLabel.AutoSize = true;
            this.phaseLabel.Location = new System.Drawing.Point(17, 167);
            this.phaseLabel.Name = "phaseLabel";
            this.phaseLabel.Size = new System.Drawing.Size(48, 17);
            this.phaseLabel.TabIndex = 7;
            this.phaseLabel.Text = "Phase";
            // 
            // phaseTextBox
            // 
            this.phaseTextBox.Location = new System.Drawing.Point(150, 170);
            this.phaseTextBox.Name = "phaseTextBox";
            this.phaseTextBox.Size = new System.Drawing.Size(100, 22);
            this.phaseTextBox.TabIndex = 6;
            this.phaseTextBox.TextChanged += new System.EventHandler(this.PhaseTextBox_TextChanged);
            // 
            // frequencyLabel
            // 
            this.frequencyLabel.AutoSize = true;
            this.frequencyLabel.Location = new System.Drawing.Point(17, 127);
            this.frequencyLabel.Name = "frequencyLabel";
            this.frequencyLabel.Size = new System.Drawing.Size(75, 17);
            this.frequencyLabel.TabIndex = 5;
            this.frequencyLabel.Text = "Frequency";
            // 
            // frequencyTextBox
            // 
            this.frequencyTextBox.Location = new System.Drawing.Point(150, 130);
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.Size = new System.Drawing.Size(100, 22);
            this.frequencyTextBox.TabIndex = 4;
            this.frequencyTextBox.TextChanged += new System.EventHandler(this.FrequencyTextBox_TextChanged);
            // 
            // cosRadioButton
            // 
            this.cosRadioButton.AutoSize = true;
            this.cosRadioButton.Location = new System.Drawing.Point(147, 87);
            this.cosRadioButton.Name = "cosRadioButton";
            this.cosRadioButton.Size = new System.Drawing.Size(53, 21);
            this.cosRadioButton.TabIndex = 3;
            this.cosRadioButton.Text = "Cos";
            this.cosRadioButton.UseVisualStyleBackColor = true;
            this.cosRadioButton.CheckedChanged += new System.EventHandler(this.CosRadioButton_CheckedChanged);
            // 
            // sinRadioButton
            // 
            this.sinRadioButton.AutoSize = true;
            this.sinRadioButton.Location = new System.Drawing.Point(17, 87);
            this.sinRadioButton.Name = "sinRadioButton";
            this.sinRadioButton.Size = new System.Drawing.Size(49, 21);
            this.sinRadioButton.TabIndex = 2;
            this.sinRadioButton.Text = "Sin";
            this.sinRadioButton.UseVisualStyleBackColor = true;
            this.sinRadioButton.CheckedChanged += new System.EventHandler(this.SinRadioButton_CheckedChanged);
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.AutoSize = true;
            this.amplitudeLabel.Location = new System.Drawing.Point(17, 47);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(70, 17);
            this.amplitudeLabel.TabIndex = 1;
            this.amplitudeLabel.Text = "Amplitude";
            this.amplitudeLabel.Click += new System.EventHandler(this.AmplitudeLabel_Click);
            // 
            // amplitudeTextBox
            // 
            this.amplitudeTextBox.Location = new System.Drawing.Point(150, 50);
            this.amplitudeTextBox.Name = "amplitudeTextBox";
            this.amplitudeTextBox.Size = new System.Drawing.Size(100, 22);
            this.amplitudeTextBox.TabIndex = 0;
            this.amplitudeTextBox.TextChanged += new System.EventHandler(this.AmplitudeTextBox_TextChanged);
            // 
            // AddNewHarmonicButton
            // 
            this.AddNewHarmonicButton.AutoSize = true;
            this.AddNewHarmonicButton.Location = new System.Drawing.Point(12, 217);
            this.AddNewHarmonicButton.Name = "AddNewHarmonicButton";
            this.AddNewHarmonicButton.Size = new System.Drawing.Size(75, 27);
            this.AddNewHarmonicButton.TabIndex = 2;
            this.AddNewHarmonicButton.Text = "Add new";
            this.AddNewHarmonicButton.UseVisualStyleBackColor = true;
            this.AddNewHarmonicButton.Click += new System.EventHandler(this.AddNewHarmonicButton_Click);
            // 
            // deleteHarmonicButton
            // 
            this.deleteHarmonicButton.AutoSize = true;
            this.deleteHarmonicButton.Location = new System.Drawing.Point(137, 217);
            this.deleteHarmonicButton.Name = "deleteHarmonicButton";
            this.deleteHarmonicButton.Size = new System.Drawing.Size(118, 27);
            this.deleteHarmonicButton.TabIndex = 3;
            this.deleteHarmonicButton.Text = "Delete Selected";
            this.deleteHarmonicButton.UseVisualStyleBackColor = true;
            this.deleteHarmonicButton.Click += new System.EventHandler(this.DeleteHarmonicButton_Click);
            // 
            // Harmonics
            // 
            this.Harmonics.Controls.Add(this.harmonicList);
            this.Harmonics.Location = new System.Drawing.Point(12, 12);
            this.Harmonics.Name = "Harmonics";
            this.Harmonics.Size = new System.Drawing.Size(265, 192);
            this.Harmonics.TabIndex = 4;
            this.Harmonics.TabStop = false;
            this.Harmonics.Text = "Harmonics";
            this.Harmonics.Enter += new System.EventHandler(this.Harmonics_Enter);
            // 
            // harmonicList
            // 
            this.harmonicList.FormattingEnabled = true;
            this.harmonicList.ItemHeight = 16;
            this.harmonicList.Location = new System.Drawing.Point(6, 47);
            this.harmonicList.Name = "harmonicList";
            this.harmonicList.Size = new System.Drawing.Size(231, 132);
            this.harmonicList.TabIndex = 0;
            this.harmonicList.SelectedIndexChanged += new System.EventHandler(this.HarmonicList_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 275);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 370);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(603, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chart";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(603, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 657);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Harmonics);
            this.Controls.Add(this.deleteHarmonicButton);
            this.Controls.Add(this.AddNewHarmonicButton);
            this.Controls.Add(this.HarmonicProperties);
            this.Name = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.HarmonicProperties.ResumeLayout(false);
            this.HarmonicProperties.PerformLayout();
            this.Harmonics.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox HarmonicProperties;
        private System.Windows.Forms.RadioButton sinRadioButton;
        private System.Windows.Forms.Label amplitudeLabel;
        private System.Windows.Forms.TextBox amplitudeTextBox;
        private System.Windows.Forms.Label phaseLabel;
        private System.Windows.Forms.TextBox phaseTextBox;
        private System.Windows.Forms.Label frequencyLabel;
        private System.Windows.Forms.TextBox frequencyTextBox;
        private System.Windows.Forms.RadioButton cosRadioButton;
        private System.Windows.Forms.Button AddNewHarmonicButton;
        private System.Windows.Forms.Button deleteHarmonicButton;
        private System.Windows.Forms.GroupBox Harmonics;
        private System.Windows.Forms.ListBox harmonicList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

