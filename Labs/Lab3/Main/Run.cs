using Lab3.Forms;
using System;
using System.Windows.Forms;

namespace Lab3.Main
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
