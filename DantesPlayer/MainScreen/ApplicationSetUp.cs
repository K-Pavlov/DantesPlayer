namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    #endregion 

    /// <summary>
    /// Starts the application 
    /// </summary>
    internal static class ApplicationSetUp
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        internal static void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainScreen.Instance);
            Application.Exit();
        }
    }
}
