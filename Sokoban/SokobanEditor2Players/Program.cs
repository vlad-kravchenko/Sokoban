using System;
using System.Windows.Forms;

namespace SokobanEditor2Players
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SokobanEditor2Players());
        }
    }
}
