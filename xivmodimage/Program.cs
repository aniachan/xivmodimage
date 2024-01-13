namespace xivmodimage
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    // Define a class to represent your mod information
    public class ModInfo
    {
        public string ModPath { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
    }
}