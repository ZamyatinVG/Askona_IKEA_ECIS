using System;
using System.Windows.Forms;
using System.Threading;

namespace Askona_IKEA_ECIS
{
    static class Program
    {
        private static Mutex m_instance;
        private const string m_appName = "Askona IKEA ECIS";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool TryCreateNewApp;
            m_instance = new Mutex(true, m_appName, out TryCreateNewApp);
            if (TryCreateNewApp)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                return;
            }
        }
    }
}