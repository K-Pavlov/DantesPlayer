namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Windows.Forms;
    #endregion
    static class StartPlayer_Entry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationSetUp.Start();
        }
    }
}
