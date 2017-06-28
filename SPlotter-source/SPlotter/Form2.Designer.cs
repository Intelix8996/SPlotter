namespace SPlotter
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.DisableAnimationsTickBox = new System.Windows.Forms.CheckBox();
            this.RangeSelect_CheckBox = new System.Windows.Forms.CheckBox();
            this.TimerEnabled_CheckBox = new System.Windows.Forms.CheckBox();
            this.TimerDelay_InputField = new System.Windows.Forms.TextBox();
            this.ms_label = new System.Windows.Forms.Label();
            this.HighPerformance_CheckBox = new System.Windows.Forms.CheckBox();
            this.ThreadSleepLabel = new System.Windows.Forms.Label();
            this.ms_Label2 = new System.Windows.Forms.Label();
            this.ThreadSleepTime_InputField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DisableAnimationsTickBox
            // 
            this.DisableAnimationsTickBox.AutoSize = true;
            this.DisableAnimationsTickBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.DisableAnimationsTickBox.Location = new System.Drawing.Point(12, 12);
            this.DisableAnimationsTickBox.Name = "DisableAnimationsTickBox";
            this.DisableAnimationsTickBox.Size = new System.Drawing.Size(180, 27);
            this.DisableAnimationsTickBox.TabIndex = 1;
            this.DisableAnimationsTickBox.Text = "Disable Animations";
            this.DisableAnimationsTickBox.UseVisualStyleBackColor = true;
            this.DisableAnimationsTickBox.CheckedChanged += new System.EventHandler(this.DisableAnimationsTickBox_CheckedChanged);
            // 
            // RangeSelect_CheckBox
            // 
            this.RangeSelect_CheckBox.AutoSize = true;
            this.RangeSelect_CheckBox.Enabled = false;
            this.RangeSelect_CheckBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.RangeSelect_CheckBox.Location = new System.Drawing.Point(12, 102);
            this.RangeSelect_CheckBox.Name = "RangeSelect_CheckBox";
            this.RangeSelect_CheckBox.Size = new System.Drawing.Size(174, 27);
            this.RangeSelect_CheckBox.TabIndex = 2;
            this.RangeSelect_CheckBox.Text = "Data Optimization";
            this.RangeSelect_CheckBox.UseVisualStyleBackColor = true;
            this.RangeSelect_CheckBox.CheckedChanged += new System.EventHandler(this.RangeSelect_CheckBox_CheckedChanged);
            // 
            // TimerEnabled_CheckBox
            // 
            this.TimerEnabled_CheckBox.AutoSize = true;
            this.TimerEnabled_CheckBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.TimerEnabled_CheckBox.Location = new System.Drawing.Point(12, 57);
            this.TimerEnabled_CheckBox.Name = "TimerEnabled_CheckBox";
            this.TimerEnabled_CheckBox.Size = new System.Drawing.Size(157, 27);
            this.TimerEnabled_CheckBox.TabIndex = 3;
            this.TimerEnabled_CheckBox.Text = "Capturing Delay";
            this.TimerEnabled_CheckBox.UseVisualStyleBackColor = true;
            this.TimerEnabled_CheckBox.CheckedChanged += new System.EventHandler(this.TimerEnabled_CheckBox_CheckedChanged);
            // 
            // TimerDelay_InputField
            // 
            this.TimerDelay_InputField.Enabled = false;
            this.TimerDelay_InputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.TimerDelay_InputField.Location = new System.Drawing.Point(175, 60);
            this.TimerDelay_InputField.Name = "TimerDelay_InputField";
            this.TimerDelay_InputField.Size = new System.Drawing.Size(48, 21);
            this.TimerDelay_InputField.TabIndex = 4;
            this.TimerDelay_InputField.TextChanged += new System.EventHandler(this.TimerDelay_InputField_TextChanged);
            // 
            // ms_label
            // 
            this.ms_label.AutoSize = true;
            this.ms_label.Location = new System.Drawing.Point(229, 68);
            this.ms_label.Name = "ms_label";
            this.ms_label.Size = new System.Drawing.Size(20, 13);
            this.ms_label.TabIndex = 5;
            this.ms_label.Text = "ms";
            // 
            // HighPerformance_CheckBox
            // 
            this.HighPerformance_CheckBox.AutoSize = true;
            this.HighPerformance_CheckBox.Enabled = false;
            this.HighPerformance_CheckBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.HighPerformance_CheckBox.Location = new System.Drawing.Point(12, 146);
            this.HighPerformance_CheckBox.Name = "HighPerformance_CheckBox";
            this.HighPerformance_CheckBox.Size = new System.Drawing.Size(235, 27);
            this.HighPerformance_CheckBox.TabIndex = 6;
            this.HighPerformance_CheckBox.Text = "High Performance Support";
            this.HighPerformance_CheckBox.UseVisualStyleBackColor = true;
            this.HighPerformance_CheckBox.CheckedChanged += new System.EventHandler(this.HighPerformance_CheckBox_CheckedChanged);
            // 
            // ThreadSleepLabel
            // 
            this.ThreadSleepLabel.AutoSize = true;
            this.ThreadSleepLabel.Enabled = false;
            this.ThreadSleepLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ThreadSleepLabel.Location = new System.Drawing.Point(8, 186);
            this.ThreadSleepLabel.Name = "ThreadSleepLabel";
            this.ThreadSleepLabel.Size = new System.Drawing.Size(158, 23);
            this.ThreadSleepLabel.TabIndex = 7;
            this.ThreadSleepLabel.Text = "Thread Sleep Time:";
            // 
            // ms_Label2
            // 
            this.ms_Label2.AutoSize = true;
            this.ms_Label2.Location = new System.Drawing.Point(229, 194);
            this.ms_Label2.Name = "ms_Label2";
            this.ms_Label2.Size = new System.Drawing.Size(20, 13);
            this.ms_Label2.TabIndex = 9;
            this.ms_Label2.Text = "ms";
            // 
            // ThreadSleepTime_InputField
            // 
            this.ThreadSleepTime_InputField.Enabled = false;
            this.ThreadSleepTime_InputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F);
            this.ThreadSleepTime_InputField.Location = new System.Drawing.Point(175, 186);
            this.ThreadSleepTime_InputField.Name = "ThreadSleepTime_InputField";
            this.ThreadSleepTime_InputField.Size = new System.Drawing.Size(48, 21);
            this.ThreadSleepTime_InputField.TabIndex = 8;
            this.ThreadSleepTime_InputField.Text = "1";
            this.ThreadSleepTime_InputField.TextChanged += new System.EventHandler(this.ThreadSleepTime_InputField_TextChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 385);
            this.Controls.Add(this.ms_Label2);
            this.Controls.Add(this.ThreadSleepTime_InputField);
            this.Controls.Add(this.ThreadSleepLabel);
            this.Controls.Add(this.HighPerformance_CheckBox);
            this.Controls.Add(this.ms_label);
            this.Controls.Add(this.TimerDelay_InputField);
            this.Controls.Add(this.TimerEnabled_CheckBox);
            this.Controls.Add(this.RangeSelect_CheckBox);
            this.Controls.Add(this.DisableAnimationsTickBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox DisableAnimationsTickBox;
        private System.Windows.Forms.CheckBox RangeSelect_CheckBox;
        private System.Windows.Forms.CheckBox TimerEnabled_CheckBox;
        private System.Windows.Forms.TextBox TimerDelay_InputField;
        private System.Windows.Forms.Label ms_label;
        private System.Windows.Forms.CheckBox HighPerformance_CheckBox;
        private System.Windows.Forms.Label ThreadSleepLabel;
        private System.Windows.Forms.Label ms_Label2;
        private System.Windows.Forms.TextBox ThreadSleepTime_InputField;
    }
}