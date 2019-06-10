namespace ChartDrawer.View.MainMenu
{
    partial class MainMenuView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.chartTableView = new System.Windows.Forms.DataGridView();
            this.amplitudeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.frequencyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.phaseErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.HarmonicProperties.SuspendLayout();
            this.Harmonics.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTableView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // HarmonicProperties
            // 
            this.HarmonicProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.phaseTextBox.MaxLength = 10;
            this.phaseTextBox.Name = "phaseTextBox";
            this.phaseTextBox.Size = new System.Drawing.Size(100, 22);
            this.phaseTextBox.TabIndex = 6;
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
            this.frequencyTextBox.MaxLength = 12;
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.Size = new System.Drawing.Size(100, 22);
            this.frequencyTextBox.TabIndex = 4;
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
            // 
            // amplitudeLabel
            // 
            this.amplitudeLabel.AutoSize = true;
            this.amplitudeLabel.Location = new System.Drawing.Point(17, 47);
            this.amplitudeLabel.Name = "amplitudeLabel";
            this.amplitudeLabel.Size = new System.Drawing.Size(70, 17);
            this.amplitudeLabel.TabIndex = 1;
            this.amplitudeLabel.Text = "Amplitude";
            // 
            // amplitudeTextBox
            // 
            this.amplitudeTextBox.Location = new System.Drawing.Point(150, 50);
            this.amplitudeTextBox.MaxLength = 10;
            this.amplitudeTextBox.Name = "amplitudeTextBox";
            this.amplitudeTextBox.Size = new System.Drawing.Size(100, 22);
            this.amplitudeTextBox.TabIndex = 0;
            this.amplitudeTextBox.TextChanged += new System.EventHandler(this.amplitudeTextBox_TextChanged);
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
            this.Harmonics.AutoSize = true;
            this.Harmonics.Controls.Add(this.harmonicList);
            this.Harmonics.Location = new System.Drawing.Point(12, 12);
            this.Harmonics.Name = "Harmonics";
            this.Harmonics.Size = new System.Drawing.Size(265, 200);
            this.Harmonics.TabIndex = 4;
            this.Harmonics.TabStop = false;
            this.Harmonics.Text = "Harmonics";
            // 
            // harmonicList
            // 
            this.harmonicList.FormattingEnabled = true;
            this.harmonicList.ItemHeight = 16;
            this.harmonicList.Location = new System.Drawing.Point(6, 47);
            this.harmonicList.Name = "harmonicList";
            this.harmonicList.Size = new System.Drawing.Size(231, 132);
            this.harmonicList.TabIndex = 0;
            this.harmonicList.Click += new System.EventHandler(this.HarmonicList_SelectedIndexClicked);
            this.harmonicList.SelectedIndexChanged += new System.EventHandler(this.HarmonicList_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tabPage2.Controls.Add(this.chartTableView);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(603, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartTableView
            // 
            this.chartTableView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.chartTableView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.chartTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.chartTableView.DefaultCellStyle = dataGridViewCellStyle1;
            this.chartTableView.Location = new System.Drawing.Point(6, 6);
            this.chartTableView.Name = "chartTableView";
            this.chartTableView.ReadOnly = true;
            this.chartTableView.RowTemplate.Height = 24;
            this.chartTableView.Size = new System.Drawing.Size(591, 329);
            this.chartTableView.TabIndex = 0;
            // 
            // amplitudeErrorProvider
            // 
            this.amplitudeErrorProvider.ContainerControl = this;
            // 
            // frequencyErrorProvider
            // 
            this.frequencyErrorProvider.ContainerControl = this;
            // 
            // phaseErrorProvider
            // 
            this.phaseErrorProvider.ContainerControl = this;
            // 
            // MainMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 657);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Harmonics);
            this.Controls.Add(this.deleteHarmonicButton);
            this.Controls.Add(this.AddNewHarmonicButton);
            this.Controls.Add(this.HarmonicProperties);
            this.MaximumSize = new System.Drawing.Size(753, 804);
            this.MinimumSize = new System.Drawing.Size(653, 704);
            this.Name = "MainMenuView";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.HarmonicProperties.ResumeLayout(false);
            this.HarmonicProperties.PerformLayout();
            this.Harmonics.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTableView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseErrorProvider)).EndInit();
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
        private System.Windows.Forms.ErrorProvider amplitudeErrorProvider;
        private System.Windows.Forms.ErrorProvider frequencyErrorProvider;
        private System.Windows.Forms.ErrorProvider phaseErrorProvider;
        private System.Windows.Forms.DataGridView chartTableView;
    }
}

