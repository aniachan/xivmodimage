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
            Application.Run(new SimpleViewForm());
        }
    }

    // Define a class to represent your mod information
    public class ModInfo
    {
        public string ModPath { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public bool IsSorted { get; set; }
    }

    // Define a class to hold image details
    public class ImageInfo
    {
        public string ImageUrl { get; set; }
        public string PageUrl { get; set; }
        public string PageTitle { get; set; }
    }

    // Define a class to hold the data from sort_order.json
    public class SortOrder
    {
        public Dictionary<string, string> Data { get; set; }
        public List<string> EmptyFolders { get; set; }
    }

    // Define an enum for different processing actions in advanced view
    public enum ModProcessingAction
    {
        Accept,
        Skip,
        NoImage
    }

}