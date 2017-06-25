namespace SPlotter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Graph = new LiveCharts.WinForms.CartesianChart();
            this.UpdateGraphTimer = new System.Windows.Forms.Timer(this.components);
            this.AddAxle_Button = new System.Windows.Forms.Button();
            this.RemoveAxle_Button = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.NameInput = new System.Windows.Forms.TextBox();
            this.ColorSelectDialog = new System.Windows.Forms.ColorDialog();
            this.PortMonitor_Text = new System.Windows.Forms.Label();
            this.SerialMonitor_Text = new System.Windows.Forms.TextBox();
            this.ColorPicker_Button = new System.Windows.Forms.Panel();
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.AxleSelect = new System.Windows.Forms.ToolStripComboBox();
            this.Open_Button = new System.Windows.Forms.ToolStripButton();
            this.Close_Button = new System.Windows.Forms.ToolStripButton();
            this.ClearPlot_Button = new System.Windows.Forms.ToolStripButton();
            this.ResetView_Button = new System.Windows.Forms.ToolStripButton();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.AxlesGroupLabel = new System.Windows.Forms.Label();
            this.COMSettingsGroup = new System.Windows.Forms.Panel();
            this.ApplyCOMPortChanges_Button = new System.Windows.Forms.Button();
            this.COMPortWriteTimeoutText = new System.Windows.Forms.TextBox();
            this.COMPortReadTimeoutText = new System.Windows.Forms.TextBox();
            this.COMPortBaudRateText = new System.Windows.Forms.TextBox();
            this.COMPortNameText = new System.Windows.Forms.TextBox();
            this.COMPortWriteTimeoutLabel = new System.Windows.Forms.Label();
            this.COMPortReadTimeOutLabel = new System.Windows.Forms.Label();
            this.COMPortBaudRateLabel = new System.Windows.Forms.Label();
            this.COMPortNameLabel = new System.Windows.Forms.Label();
            this.COMSettingsLabel = new System.Windows.Forms.Label();
            this.Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.Tools.SuspendLayout();
            this.panel1.SuspendLayout();
            this.COMSettingsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM4";
            this.serialPort1.ReadTimeout = 500;
            this.serialPort1.WriteTimeout = 500;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1});
            this.Status.Location = new System.Drawing.Point(0, 658);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(987, 22);
            this.Status.TabIndex = 4;
            this.Status.Text = "Status";
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel1.Text = "StatusLabel";
            // 
            // Graph
            // 
            this.Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Graph.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Graph.Location = new System.Drawing.Point(350, 33);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(637, 624);
            this.Graph.TabIndex = 5;
            this.Graph.Text = "Graph";
            // 
            // UpdateGraphTimer
            // 
            this.UpdateGraphTimer.Interval = 500;
            this.UpdateGraphTimer.Tick += new System.EventHandler(this.UpdateGraphTimer_Tick);
            // 
            // AddAxle_Button
            // 
            this.AddAxle_Button.Location = new System.Drawing.Point(249, 20);
            this.AddAxle_Button.Name = "AddAxle_Button";
            this.AddAxle_Button.Size = new System.Drawing.Size(75, 23);
            this.AddAxle_Button.TabIndex = 6;
            this.AddAxle_Button.Text = "Add";
            this.AddAxle_Button.UseVisualStyleBackColor = true;
            this.AddAxle_Button.Click += new System.EventHandler(this.AddAxle_Button_Click);
            // 
            // RemoveAxle_Button
            // 
            this.RemoveAxle_Button.Location = new System.Drawing.Point(249, 75);
            this.RemoveAxle_Button.Name = "RemoveAxle_Button";
            this.RemoveAxle_Button.Size = new System.Drawing.Size(75, 23);
            this.RemoveAxle_Button.TabIndex = 7;
            this.RemoveAxle_Button.Text = "Remove";
            this.RemoveAxle_Button.UseVisualStyleBackColor = true;
            this.RemoveAxle_Button.Click += new System.EventHandler(this.RemoveAxle_Button_Click);
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(80, 23);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(100, 20);
            this.NameInput.TabIndex = 10;
            // 
            // PortMonitor_Text
            // 
            this.PortMonitor_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PortMonitor_Text.AutoSize = true;
            this.PortMonitor_Text.Location = new System.Drawing.Point(0, 330);
            this.PortMonitor_Text.Name = "PortMonitor_Text";
            this.PortMonitor_Text.Size = new System.Drawing.Size(0, 13);
            this.PortMonitor_Text.TabIndex = 12;
            // 
            // SerialMonitor_Text
            // 
            this.SerialMonitor_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SerialMonitor_Text.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SerialMonitor_Text.Font = new System.Drawing.Font("Orator Std", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialMonitor_Text.Location = new System.Drawing.Point(12, 434);
            this.SerialMonitor_Text.MaxLength = 60000;
            this.SerialMonitor_Text.Multiline = true;
            this.SerialMonitor_Text.Name = "SerialMonitor_Text";
            this.SerialMonitor_Text.ReadOnly = true;
            this.SerialMonitor_Text.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SerialMonitor_Text.Size = new System.Drawing.Size(331, 211);
            this.SerialMonitor_Text.TabIndex = 13;
            // 
            // ColorPicker_Button
            // 
            this.ColorPicker_Button.BackColor = System.Drawing.Color.SteelBlue;
            this.ColorPicker_Button.Location = new System.Drawing.Point(80, 78);
            this.ColorPicker_Button.Name = "ColorPicker_Button";
            this.ColorPicker_Button.Size = new System.Drawing.Size(100, 20);
            this.ColorPicker_Button.TabIndex = 14;
            this.ColorPicker_Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorPicker_Button_MouseDown);
            // 
            // Tools
            // 
            this.Tools.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tools.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AxleSelect,
            this.Open_Button,
            this.Close_Button,
            this.ClearPlot_Button,
            this.ResetView_Button});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Tools.Size = new System.Drawing.Size(987, 47);
            this.Tools.TabIndex = 15;
            // 
            // AxleSelect
            // 
            this.AxleSelect.DropDownHeight = 120;
            this.AxleSelect.IntegralHeight = false;
            this.AxleSelect.Name = "AxleSelect";
            this.AxleSelect.Size = new System.Drawing.Size(121, 47);
            this.AxleSelect.Text = "Axles";
            // 
            // Open_Button
            // 
            this.Open_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open_Button.Image = ((System.Drawing.Image)(resources.GetObject("Open_Button.Image")));
            this.Open_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open_Button.Name = "Open_Button";
            this.Open_Button.Size = new System.Drawing.Size(44, 44);
            this.Open_Button.Text = "Connect";
            this.Open_Button.ToolTipText = "Connect";
            this.Open_Button.Click += new System.EventHandler(this.Open_Button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Close_Button.Image = ((System.Drawing.Image)(resources.GetObject("Close_Button.Image")));
            this.Close_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(44, 44);
            this.Close_Button.Text = "Disconnect";
            this.Close_Button.ToolTipText = "Disconnect";
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // ClearPlot_Button
            // 
            this.ClearPlot_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearPlot_Button.Image = ((System.Drawing.Image)(resources.GetObject("ClearPlot_Button.Image")));
            this.ClearPlot_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearPlot_Button.Name = "ClearPlot_Button";
            this.ClearPlot_Button.Size = new System.Drawing.Size(44, 44);
            this.ClearPlot_Button.Text = "Clear";
            this.ClearPlot_Button.Click += new System.EventHandler(this.ClearPlot_Button_Click);
            // 
            // ResetView_Button
            // 
            this.ResetView_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ResetView_Button.Image = ((System.Drawing.Image)(resources.GetObject("ResetView_Button.Image")));
            this.ResetView_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetView_Button.Name = "ResetView_Button";
            this.ResetView_Button.Size = new System.Drawing.Size(44, 44);
            this.ResetView_Button.Text = "Reset View";
            this.ResetView_Button.ToolTipText = "Reset View";
            this.ResetView_Button.Click += new System.EventHandler(this.ResetView_Button_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(12, 23);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(63, 20);
            this.NameLabel.TabIndex = 16;
            this.NameLabel.Text = "Name:";
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F);
            this.ColorLabel.Location = new System.Drawing.Point(12, 78);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(58, 20);
            this.ColorLabel.TabIndex = 17;
            this.ColorLabel.Text = "Color:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.RemoveAxle_Button);
            this.panel1.Controls.Add(this.AddAxle_Button);
            this.panel1.Controls.Add(this.NameInput);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Controls.Add(this.ColorLabel);
            this.panel1.Controls.Add(this.ColorPicker_Button);
            this.panel1.Location = new System.Drawing.Point(12, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 109);
            this.panel1.TabIndex = 18;
            // 
            // AxlesGroupLabel
            // 
            this.AxlesGroupLabel.AutoSize = true;
            this.AxlesGroupLabel.Location = new System.Drawing.Point(12, 56);
            this.AxlesGroupLabel.Name = "AxlesGroupLabel";
            this.AxlesGroupLabel.Size = new System.Drawing.Size(32, 13);
            this.AxlesGroupLabel.TabIndex = 19;
            this.AxlesGroupLabel.Text = "Axles";
            // 
            // COMSettingsGroup
            // 
            this.COMSettingsGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.COMSettingsGroup.Controls.Add(this.ApplyCOMPortChanges_Button);
            this.COMSettingsGroup.Controls.Add(this.COMPortWriteTimeoutText);
            this.COMSettingsGroup.Controls.Add(this.COMPortReadTimeoutText);
            this.COMSettingsGroup.Controls.Add(this.COMPortBaudRateText);
            this.COMSettingsGroup.Controls.Add(this.COMPortNameText);
            this.COMSettingsGroup.Controls.Add(this.COMPortWriteTimeoutLabel);
            this.COMSettingsGroup.Controls.Add(this.COMPortReadTimeOutLabel);
            this.COMSettingsGroup.Controls.Add(this.COMPortBaudRateLabel);
            this.COMSettingsGroup.Controls.Add(this.COMPortNameLabel);
            this.COMSettingsGroup.Location = new System.Drawing.Point(12, 202);
            this.COMSettingsGroup.Name = "COMSettingsGroup";
            this.COMSettingsGroup.Size = new System.Drawing.Size(331, 216);
            this.COMSettingsGroup.TabIndex = 20;
            // 
            // ApplyCOMPortChanges_Button
            // 
            this.ApplyCOMPortChanges_Button.Location = new System.Drawing.Point(3, 186);
            this.ApplyCOMPortChanges_Button.Name = "ApplyCOMPortChanges_Button";
            this.ApplyCOMPortChanges_Button.Size = new System.Drawing.Size(321, 23);
            this.ApplyCOMPortChanges_Button.TabIndex = 26;
            this.ApplyCOMPortChanges_Button.Text = "Apply Changes";
            this.ApplyCOMPortChanges_Button.UseVisualStyleBackColor = true;
            this.ApplyCOMPortChanges_Button.Click += new System.EventHandler(this.ApplyCOMPortChanges_Button_Click);
            // 
            // COMPortWriteTimeoutText
            // 
            this.COMPortWriteTimeoutText.Location = new System.Drawing.Point(224, 156);
            this.COMPortWriteTimeoutText.Name = "COMPortWriteTimeoutText";
            this.COMPortWriteTimeoutText.Size = new System.Drawing.Size(100, 20);
            this.COMPortWriteTimeoutText.TabIndex = 25;
            this.COMPortWriteTimeoutText.Text = "500";
            // 
            // COMPortReadTimeoutText
            // 
            this.COMPortReadTimeoutText.Location = new System.Drawing.Point(224, 110);
            this.COMPortReadTimeoutText.Name = "COMPortReadTimeoutText";
            this.COMPortReadTimeoutText.Size = new System.Drawing.Size(100, 20);
            this.COMPortReadTimeoutText.TabIndex = 24;
            this.COMPortReadTimeoutText.Text = "500";
            // 
            // COMPortBaudRateText
            // 
            this.COMPortBaudRateText.Location = new System.Drawing.Point(224, 63);
            this.COMPortBaudRateText.Name = "COMPortBaudRateText";
            this.COMPortBaudRateText.Size = new System.Drawing.Size(100, 20);
            this.COMPortBaudRateText.TabIndex = 23;
            this.COMPortBaudRateText.Text = "9600";
            // 
            // COMPortNameText
            // 
            this.COMPortNameText.Location = new System.Drawing.Point(224, 16);
            this.COMPortNameText.Name = "COMPortNameText";
            this.COMPortNameText.Size = new System.Drawing.Size(100, 20);
            this.COMPortNameText.TabIndex = 22;
            this.COMPortNameText.Text = "COM1";
            // 
            // COMPortWriteTimeoutLabel
            // 
            this.COMPortWriteTimeoutLabel.AutoSize = true;
            this.COMPortWriteTimeoutLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.COMPortWriteTimeoutLabel.Location = new System.Drawing.Point(12, 154);
            this.COMPortWriteTimeoutLabel.Name = "COMPortWriteTimeoutLabel";
            this.COMPortWriteTimeoutLabel.Size = new System.Drawing.Size(216, 20);
            this.COMPortWriteTimeoutLabel.TabIndex = 21;
            this.COMPortWriteTimeoutLabel.Text = "COM Port Write Timeout:";
            // 
            // COMPortReadTimeOutLabel
            // 
            this.COMPortReadTimeOutLabel.AutoSize = true;
            this.COMPortReadTimeOutLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.COMPortReadTimeOutLabel.Location = new System.Drawing.Point(12, 108);
            this.COMPortReadTimeOutLabel.Name = "COMPortReadTimeOutLabel";
            this.COMPortReadTimeOutLabel.Size = new System.Drawing.Size(212, 20);
            this.COMPortReadTimeOutLabel.TabIndex = 20;
            this.COMPortReadTimeOutLabel.Text = "COM Port Read Timeout:";
            // 
            // COMPortBaudRateLabel
            // 
            this.COMPortBaudRateLabel.AutoSize = true;
            this.COMPortBaudRateLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.COMPortBaudRateLabel.Location = new System.Drawing.Point(12, 61);
            this.COMPortBaudRateLabel.Name = "COMPortBaudRateLabel";
            this.COMPortBaudRateLabel.Size = new System.Drawing.Size(183, 20);
            this.COMPortBaudRateLabel.TabIndex = 19;
            this.COMPortBaudRateLabel.Text = "COM Port Baud Rate:";
            // 
            // COMPortNameLabel
            // 
            this.COMPortNameLabel.AutoSize = true;
            this.COMPortNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.COMPortNameLabel.Location = new System.Drawing.Point(12, 14);
            this.COMPortNameLabel.Name = "COMPortNameLabel";
            this.COMPortNameLabel.Size = new System.Drawing.Size(145, 20);
            this.COMPortNameLabel.TabIndex = 18;
            this.COMPortNameLabel.Text = "COM Port Name:";
            // 
            // COMSettingsLabel
            // 
            this.COMSettingsLabel.AutoSize = true;
            this.COMSettingsLabel.Location = new System.Drawing.Point(12, 186);
            this.COMSettingsLabel.Name = "COMSettingsLabel";
            this.COMSettingsLabel.Size = new System.Drawing.Size(72, 13);
            this.COMSettingsLabel.TabIndex = 21;
            this.COMSettingsLabel.Text = "COM Settings";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(987, 680);
            this.Controls.Add(this.COMSettingsLabel);
            this.Controls.Add(this.COMSettingsGroup);
            this.Controls.Add(this.AxlesGroupLabel);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.SerialMonitor_Text);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.PortMonitor_Text);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SPlotter v1.0";
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.COMSettingsGroup.ResumeLayout(false);
            this.COMSettingsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
        private LiveCharts.WinForms.CartesianChart Graph;
        private System.Windows.Forms.Timer UpdateGraphTimer;
        private System.Windows.Forms.Button AddAxle_Button;
        private System.Windows.Forms.Button RemoveAxle_Button;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.ColorDialog ColorSelectDialog;
        private System.Windows.Forms.Label PortMonitor_Text;
        private System.Windows.Forms.TextBox SerialMonitor_Text;
        private System.Windows.Forms.Panel ColorPicker_Button;
        private System.Windows.Forms.ToolStrip Tools;
        public System.Windows.Forms.ToolStripComboBox AxleSelect;
        private System.Windows.Forms.ToolStripButton Open_Button;
        private System.Windows.Forms.ToolStripButton Close_Button;
        private System.Windows.Forms.ToolStripButton ClearPlot_Button;
        private System.Windows.Forms.ToolStripButton ResetView_Button;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AxlesGroupLabel;
        private System.Windows.Forms.Panel COMSettingsGroup;
        private System.Windows.Forms.Label COMSettingsLabel;
        private System.Windows.Forms.TextBox COMPortWriteTimeoutText;
        private System.Windows.Forms.TextBox COMPortReadTimeoutText;
        private System.Windows.Forms.TextBox COMPortBaudRateText;
        private System.Windows.Forms.TextBox COMPortNameText;
        private System.Windows.Forms.Label COMPortWriteTimeoutLabel;
        private System.Windows.Forms.Label COMPortReadTimeOutLabel;
        private System.Windows.Forms.Label COMPortBaudRateLabel;
        private System.Windows.Forms.Label COMPortNameLabel;
        private System.Windows.Forms.Button ApplyCOMPortChanges_Button;
    }
}

