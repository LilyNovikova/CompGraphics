using Lab5.Forms;
using System;
using System.Windows.Forms;

namespace Lab5.Main
{
    static class Run
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DrawForm());
        }
    }
}
