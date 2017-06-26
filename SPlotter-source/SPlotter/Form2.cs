using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPlotter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DisableAnimationsTickBox.Checked = Program.MainForm.Graph.DisableAnimations;
            RangeSelect_CheckBox.Checked = Program.MainForm.isRangeAddEnabled;
            TimerEnabled_CheckBox.Checked = Program.MainForm.UpdateGraphTimer.Enabled;
            TimerEnabled_CheckBox.Checked = TimerDelay_InputField.Enabled;
            TimerEnabled_CheckBox.Checked = RangeSelect_CheckBox.Enabled;
            TimerDelay_InputField.Text = Convert.ToString(Program.MainForm.UpdateGraphTimer.Interval);
        }

        private void DisableAnimationsTickBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.MainForm.Graph.DisableAnimations = DisableAnimationsTickBox.Checked;
        }

        private void Form2_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Program.MainForm.isSettingsOpen = false;
        }

        private void RangeSelect_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.MainForm.isRangeAddEnabled = RangeSelect_CheckBox.Checked;
        }

        private void TimerEnabled_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.MainForm.UpdateGraphTimer.Enabled = TimerEnabled_CheckBox.Checked;
            TimerDelay_InputField.Enabled = TimerEnabled_CheckBox.Checked;
            RangeSelect_CheckBox.Enabled = TimerEnabled_CheckBox.Checked;
        }

        private void TimerDelay_InputField_TextChanged(object sender, EventArgs e)
        {
            Program.MainForm.UpdateGraphTimer.Interval = Convert.ToInt32(TimerDelay_InputField.Text);
        }
    }
}
