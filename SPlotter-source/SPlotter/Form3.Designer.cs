namespace SPlotter
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.GaugeCPU = new LiveCharts.WinForms.SolidGauge();
            this.PerformanceCounterCPU = new System.Diagnostics.PerformanceCounter();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.GaugeMem = new LiveCharts.WinForms.SolidGauge();
            this.PerformanceCounterMEM = new System.Diagnostics.PerformanceCounter();
            this.MemLabel = new System.Windows.Forms.Label();
            this.ProcessorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceCounterCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceCounterMEM)).BeginInit();
            this.SuspendLayout();
            // 
            // GaugeCPU
            // 
            this.GaugeCPU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GaugeCPU.Location = new System.Drawing.Point(0, 0);
            this.GaugeCPU.Name = "GaugeCPU";
            this.GaugeCPU.Size = new System.Drawing.Size(312, 460);
            this.GaugeCPU.TabIndex = 0;
            this.GaugeCPU.Text = "CPU Time %";
            // 
            // PerformanceCounterCPU
            // 
            this.PerformanceCounterCPU.CategoryName = "Processor";
            this.PerformanceCounterCPU.CounterName = "% Processor Time";
            this.PerformanceCounterCPU.InstanceName = "_Total";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 650;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // GaugeMem
            // 
            this.GaugeMem.Dock = System.Windows.Forms.DockStyle.Right;
            this.GaugeMem.Location = new System.Drawing.Point(373, 0);
            this.GaugeMem.Name = "GaugeMem";
            this.GaugeMem.Size = new System.Drawing.Size(324, 460);
            this.GaugeMem.TabIndex = 1;
            this.GaugeMem.Text = "GaugeMem";
            // 
            // PerformanceCounterMEM
            // 
            this.PerformanceCounterMEM.CategoryName = "Process";
            this.PerformanceCounterMEM.CounterName = "Working Set";
            this.PerformanceCounterMEM.InstanceName = "Process.GetCurrentProcess().ProcessName";
            // 
            // MemLabel
            // 
            this.MemLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MemLabel.AutoSize = true;
            this.MemLabel.Location = new System.Drawing.Point(515, 447);
            this.MemLabel.Name = "MemLabel";
            this.MemLabel.Size = new System.Drawing.Size(182, 13);
            this.MemLabel.TabIndex = 3;
            this.MemLabel.Text = "Memory Usage by this Process in MB";
            // 
            // ProcessorLabel
            // 
            this.ProcessorLabel.AutoSize = true;
            this.ProcessorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProcessorLabel.Location = new System.Drawing.Point(0, 447);
            this.ProcessorLabel.Name = "ProcessorLabel";
            this.ProcessorLabel.Size = new System.Drawing.Size(159, 13);
            this.ProcessorLabel.TabIndex = 2;
            this.ProcessorLabel.Text = "CPU Usage by this Process in %";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 460);
            this.Controls.Add(this.MemLabel);
            this.Controls.Add(this.ProcessorLabel);
            this.Controls.Add(this.GaugeMem);
            this.Controls.Add(this.GaugeCPU);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "System Monitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceCounterCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceCounterMEM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.SolidGauge GaugeCPU;
        private System.Diagnostics.PerformanceCounter PerformanceCounterCPU;
        private System.Windows.Forms.Timer Timer;
        private LiveCharts.WinForms.SolidGauge GaugeMem;
        private System.Diagnostics.PerformanceCounter PerformanceCounterMEM;
        private System.Windows.Forms.Label MemLabel;
        private System.Windows.Forms.Label ProcessorLabel;
    }
}