using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChoThueNha
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //dung
            //dung3
            Application.EnableVisualStyles();
            //hehe
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fMain());
            //edit
            Application.Run(new SplashScreen());
        }
    }
}
