using IniParser;
using IniParser.Model;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;

namespace ViTrader
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("settings.ini");
                string lan = data["Localization"]["language"];

                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lan);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(lan);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                LoginWindow window = new LoginWindow();
                window.Show();

                Application.Run();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
