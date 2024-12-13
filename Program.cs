using BadmintonManager;
using BadmintonManager.GUI;
using System;
using System.Windows.Forms;

namespace BadmintonManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmThemKhachHang());
        }
    }
}
