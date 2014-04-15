using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MainScreen
{
    internal static class ApplicationSetUp
    {
        internal static MainScreen mainScreen;
        /// <summary>
        /// Starts the application
        /// creating the singleton instance
        /// of the mainscreen
        /// </summary>
        internal static void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainScreen = MainScreen.Instance;
            Application.Run(mainScreen);
            Application.Exit();
        }
    }
}
