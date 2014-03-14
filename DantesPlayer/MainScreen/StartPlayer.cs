namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Windows.Forms;
    #endregion
    static class StartPlayer
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainScreen());
            Application.Exit();
        }
    }
}
