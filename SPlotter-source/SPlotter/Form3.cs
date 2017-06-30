using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SPlotter
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            PerformanceCounterMEM.InstanceName = Process.GetCurrentProcess().ProcessName;

            GaugeCPU.To = 100;
            GaugeMem.To = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            GaugeMem.To = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();

            GaugeCPU.Value = Convert.ToInt32(PerformanceCounterCPU.NextValue());
            GaugeMem.Value = Convert.ToInt32(PerformanceCounterMEM.NextValue()/1024/1024);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.MainForm.isCPUMonitorOpen = false;
        }
    }

    public static class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
    }
}
