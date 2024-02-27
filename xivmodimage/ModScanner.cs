using Newtonsoft.Json;

namespace xivmodimage
{
    public class ModScanner
    {
        private Action<string> logMessageCallback;

        public ModScanner(Action<string> logMessageCallback)
        {
            this.logMessageCallback = logMessageCallback;
        }
        public List<ModInfo> ScanDirectories(string rootDirectory)
        {
            List<ModInfo> modInfoList = new List<ModInfo>();

            string[] subDirectories = Directory.GetDirectories(rootDirectory);

            foreach (string subDirectory in subDirectories)
            {
                string imagesDirectory = Path.Combine(subDirectory, "images");

                if (!Directory.Exists(imagesDirectory))
                {
                    ProcessMetaJson(subDirectory, modInfoList);
                }
            }

            return modInfoList;
        }

        private void ProcessMetaJson(string modDirectory, List<ModInfo> modInfoList)
        {
            string metaJsonPath = Path.Combine(modDirectory, "meta.json");

            if (File.Exists(metaJsonPath))
            {
                try
                {
                    string jsonContent = File.ReadAllText(metaJsonPath);
                    ModInfo modInfo = JsonConvert.DeserializeObject<ModInfo>(jsonContent);

                    modInfo.ModPath = modDirectory;
                    modInfoList.Add(modInfo);

                    logMessageCallback($"Processed {modInfo.Name} in {Path.GetFileName(modDirectory)}");
                }
                catch (Exception ex)
                {
                    logMessageCallback($"Error processing meta.json in {modDirectory}: {ex.Message}");
                }
            }
        }

        public SortOrder ReadSortOrderJson(string filePath)
        {
            try
            {
                string jsonText = File.ReadAllText(filePath);
                SortOrder sortOrder = JsonConvert.DeserializeObject<SortOrder>(jsonText);
                return sortOrder;
            }
            catch (Exception ex)
            {
                logMessageCallback($"Error reading JSON file: {ex.Message}");
                return null;
            }
        }
    }
}
