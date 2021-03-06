﻿namespace ChartDrawer.View.AddingHarmonic
{
    partial class AddingHarmonicsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addingNewHarmonicBox = new System.Windows.Forms.GroupBox();
            this.harmonicStringPresentation = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.createHarmonicButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.phaseTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.frequencyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cosRadioButton = new System.Windows.Forms.RadioButton();
            this.sinRadioButton = new System.Windows.Forms.RadioButton();
            this.amplitudeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.amplitudeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.frequencyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.phaseErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.addingNewHarmonicBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // addingNewHarmonicBox
            // 
            this.addingNewHarmonicBox.AutoSize = true;
            this.addingNewHarmonicBox.Controls.Add(this.harmonicStringPresentation);
            this.addingNewHarmonicBox.Controls.Add(this.cancelButton);
            this.addingNewHarmonicBox.Controls.Add(this.createHarmonicButton);
            this.addingNewHarmonicBox.Controls.Add(this.label4);
            this.addingNewHarmonicBox.Controls.Add(this.phaseTextBox);
            this.addingNewHarmonicBox.Controls.Add(this.label3);
            this.addingNewHarmonicBox.Controls.Add(this.frequencyTextBox);
            this.addingNewHarmonicBox.Controls.Add(this.label2);
            this.addingNewHarmonicBox.Controls.Add(this.cosRadioButton);
            this.addingNewHarmonicBox.Controls.Add(this.sinRadioButton);
            this.addingNewHarmonicBox.Controls.Add(this.amplitudeTextBox);
            this.addingNewHarmonicBox.Controls.Add(this.label1);
            this.addingNewHarmonicBox.Location = new System.Drawing.Point(12, 12);
            this.addingNewHarmonicBox.Name = "addingNewHarmonicBox";
            this.addingNewHarmonicBox.Size = new System.Drawing.Size(278, 345);
            this.addingNewHarmonicBox.TabIndex = 0;
            this.addingNewHarmonicBox.TabStop = false;
            this.addingNewHarmonicBox.Text = "Add new harmonic";
            // 
            // harmonicStringPresentation
            // 
            this.harmonicStringPresentation.AutoSize = true;
            this.harmonicStringPresentation.Location = new System.Drawing.Point(13, 225);
            this.harmonicStringPresentation.Name = "harmonicStringPresentation";
            this.harmonicStringPresentation.Size = new System.Drawing.Size(0, 17);
            this.harmonicStringPresentation.TabIndex = 11;
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Location = new System.Drawing.Point(197, 260);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 27);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // createHarmonicButton
            // 
            this.createHarmonicButton.AutoSize = true;
            this.createHarmonicButton.Location = new System.Drawing.Point(12, 260);
            this.createHarmonicButton.Name = "createHarmonicButton";
            this.createHarmonicButton.Size = new System.Drawing.Size(75, 27);
            this.createHarmonicButton.TabIndex = 9;
            this.createHarmonicButton.Text = "Ok";
            this.createHarmonicButton.UseVisualStyleBackColor = true;
            this.createHarmonicButton.Click += new System.EventHandler(this.CreateHarmonic_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 17);
            this.label4.TabIndex = 8;
            // 
            // phaseTextBox
            // 
            this.phaseTextBox.Location = new System.Drawing.Point(146, 162);
            this.phaseTextBox.MaxLength = 10;
            this.phaseTextBox.Name = "phaseTextBox";
            this.phaseTextBox.Size = new System.Drawing.Size(100, 22);
            this.phaseTextBox.TabIndex = 7;
            this.phaseTextBox.TextChanged += new System.EventHandler(this.PhaseTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phase";
            // 
            // frequencyTextBox
            // 
            this.frequencyTextBox.Location = new System.Drawing.Point(146, 122);
            this.frequencyTextBox.MaxLength = 10;
            this.frequencyTextBox.Name = "frequencyTextBox";
            this.frequencyTextBox.Size = new System.Drawing.Size(100, 22);
            this.frequencyTextBox.TabIndex = 5;
            this.frequencyTextBox.TextChanged += new System.EventHandler(this.FrequencyTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Frequency";
            // 
            // cosRadioButton
            // 
            this.cosRadioButton.AutoSize = true;
            this.cosRadioButton.Location = new System.Drawing.Point(146, 87);
            this.cosRadioButton.Name = "cosRadioButton";
            this.cosRadioButton.Size = new System.Drawing.Size(53, 21);
            this.cosRadioButton.TabIndex = 3;
            this.cosRadioButton.TabStop = true;
            this.cosRadioButton.Text = "Cos";
            this.cosRadioButton.UseVisualStyleBackColor = true;
            this.cosRadioButton.CheckedChanged += new System.EventHandler(this.CosRadioButton_CheckedChanged);
            // 
            // sinRadioButton
            // 
            this.sinRadioButton.AutoSize = true;
            this.sinRadioButton.Location = new System.Drawing.Point(25, 87);
            this.sinRadioButton.Name = "sinRadioButton";
            this.sinRadioButton.Size = new System.Drawing.Size(49, 21);
            this.sinRadioButton.TabIndex = 2;
            this.sinRadioButton.TabStop = true;
            this.sinRadioButton.Text = "Sin";
            this.sinRadioButton.UseVisualStyleBackColor = true;
            this.sinRadioButton.CheckedChanged += new System.EventHandler(this.SinRadioButton_CheckedChanged);
            // 
            // amplitudeTextBox
            // 
            this.amplitudeTextBox.Location = new System.Drawing.Point(146, 42);
            this.amplitudeTextBox.MaxLength = 10;
            this.amplitudeTextBox.Name = "amplitudeTextBox";
            this.amplitudeTextBox.Size = new System.Drawing.Size(100, 22);
            this.amplitudeTextBox.TabIndex = 1;
            this.amplitudeTextBox.TextChanged += new System.EventHandler(this.AmplitudeTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amplitude";
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
            // AddingHarmonicsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 371);
            this.Controls.Add(this.addingNewHarmonicBox);
            this.MaximumSize = new System.Drawing.Size(321, 418);
            this.MinimumSize = new System.Drawing.Size(321, 418);
            this.Name = "AddingHarmonicsView";
            this.Text = "AddingNewHarmonics";
            this.addingNewHarmonicBox.ResumeLayout(false);
            this.addingNewHarmonicBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudeErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frequencyErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phaseErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox addingNewHarmonicBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button createHarmonicButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox phaseTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox frequencyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton cosRadioButton;
        private System.Windows.Forms.RadioButton sinRadioButton;
        private System.Windows.Forms.TextBox amplitudeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label harmonicStringPresentation;
        private System.Windows.Forms.ErrorProvider amplitudeErrorProvider;
        private System.Windows.Forms.ErrorProvider frequencyErrorProvider;
        private System.Windows.Forms.ErrorProvider phaseErrorProvider;
    }
}