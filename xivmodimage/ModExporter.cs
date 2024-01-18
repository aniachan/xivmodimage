using System.ComponentModel;
using System.IO.Compression;

namespace xivmodimage
{
    public class ModExporter
    {
        private Action<string> logMessageCallback;

        public ModExporter(Action<string> logMessageCallback)
        {
            this.logMessageCallback = logMessageCallback;
        }

        public void ExportMods(List<string> modDirectories, string exportPath, BackgroundWorker worker)
        {
            for (int i = 0; i < modDirectories.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    return;
                }

                string modDirectory = modDirectories[i];
                int progressPercentage = (i + 1) * 100 / modDirectories.Count;

                worker.ReportProgress(progressPercentage, $"Exporting mod {i + 1}/{modDirectories.Count}");

                if (Directory.Exists(modDirectory))
                {
                    string metaJsonPath = Path.Combine(modDirectory, "meta.json");

                    if (File.Exists(metaJsonPath))
                    {
                        try
                        {
                            string exportFileName = Path.Combine(exportPath, $"{Path.GetFileName(modDirectory)}.pmp");
                            ZipFile.CreateFromDirectory(modDirectory, exportFileName, CompressionLevel.Optimal, false);

                            logMessageCallback($"Exported mod successfully: {Path.GetFileName(modDirectory)}");
                        }
                        catch (Exception ex)
                        {
                            logMessageCallback($"Error exporting mod: {ex.Message}");
                        }
                    }
                    else
                    {
                        logMessageCallback($"Error exporting mod: Missing meta.json - {modDirectory}");
                    }
                }
                else
                {
                    logMessageCallback($"Error exporting mod: Directory not found - {modDirectory}");
                }
            }
        }
    }
}
