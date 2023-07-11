using System.Diagnostics;

namespace Snippets
{
    internal static class Program
    {
        public const string APP = "ClipboardSnippets";

        public static Snippets core = new Snippets();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Debug.WriteLine("Loading snippets...");
            core.Load();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new PrimaryForm());

            Debug.WriteLine("Saving snippets...");
            core.Save();

        }
    }
}