using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SPlotter
{
    static class Program
    {
        public static Form1 MainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainForm = new Form1());
        }
    }
}
