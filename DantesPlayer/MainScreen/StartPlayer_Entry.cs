namespace MainScreen
{
    #region Namespaces
    using System;
    using System.Windows.Forms;
    #endregion
    /// <summary>
    /// The class holding the entry point method
    /// </summary>
    public static class StartPlayer_Entry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ApplicationSetUp.Start();
        }
    }
}
