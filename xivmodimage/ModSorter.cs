using Newtonsoft.Json;
using System.Text;
using System.Xml;

namespace xivmodimage
{
    internal class ModSorter
    {
        private Action<string> logMessageCallback;

        public ModSorter(Action<string> logMessageCallback)
        {
            this.logMessageCallback = logMessageCallback;
        }


        public void Sort(List<string> modDirectories, SortOrder modSortOrder)
        {
            // Apply mod sorting rules and update the sortorder object
            for (int i = 0; i < modDirectories.Count; i++)
            {
                if (Directory.Exists(modDirectories[i]))
                {
                    string metaJsonPath = Path.Combine(modDirectories[i], "meta.json");

                    if (File.Exists(metaJsonPath))
                    {
                        try
                        {
                            SortMod(modDirectories[i], modSortOrder);
                        }
                        catch (Exception ex)
                        {
                            logMessageCallback($"Error sorting mod: {ex.Message}");
                        }
                    }
                    else
                    {
                        logMessageCallback($"Error sorting mod: Missing meta.json - {modDirectories[i]}");
                    }
                }
                else
                {
                    logMessageCallback($"Error sorting mod: Directory not found - {modDirectories[i]}");
                }
            }
        }

        private void SortMod(string modDirectory, SortOrder modSortOrder)
        {
            var modName = new DirectoryInfo(modDirectory).Name;

            if (!CheckKeyExistence(modSortOrder, modName))
            {
                try
                {
                    string[] filePaths = Directory.GetFiles(modDirectory, "*", SearchOption.AllDirectories);

                    // Perform different actions based on the file path
                    if (CheckModContains(filePaths, modDirectory, "obj\\hair"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/hair");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "emote"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/emote");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "animation"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/animation");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "vfx"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/vfx");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "obj\\face"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/face");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "decal_face"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/facepaint");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "_sho_"))
                    {
                        if (CheckModContains(filePaths, modDirectory, "_dwn_"))
                        {

                        }
                        else if (CheckModContains(filePaths, modDirectory, "_top_"))
                        {

                        } else
                        {
                            SetSortPath(modSortOrder, modName, "_autosort/shoes");
                            return;
                        }
                    }
                    else if (CheckModContains(filePaths, modDirectory, "chara\\equipment"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/clothing");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "chara\\accessory"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/accessory");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "furniture"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/furniture");
                        return;
                    }
                    else if (CheckModContains(filePaths, modDirectory, "minion"))
                    {
                        SetSortPath(modSortOrder, modName, "_autosort/minion");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error scanning directory: {ex.Message}");
                }
            }
        }

        private bool CheckModContains(string[] modFiles, string modDirectory, string subString)
        {
            foreach (string filePath in modFiles)
            {
                string relativePath = filePath.Substring(modDirectory.Length + 1);

                // Perform different actions based on the file path
                if (relativePath.Contains(subString))
                {
                    return true;
                }
            }
            return false;
        }

        private void SetSortPath(SortOrder modSortOrder, string modName, string sortPath)
        {
            logMessageCallback($"Sorting mod {modName} as {sortPath}");
            string fullPath = sortPath+ "/" + modName;
            UpdateSortOrderValue(modSortOrder, modName, fullPath);
        }

        private static bool CheckKeyExistence(SortOrder sortOrder, string key)
        {
            if (sortOrder == null || string.IsNullOrEmpty(key))
                return false;

            return sortOrder.Data.ContainsKey(key);
        }

        public void UpdateSortOrderValue(SortOrder sortOrder, string key, string newValue)
        {
            if (sortOrder == null)
            {
                logMessageCallback("Sort order object is null.");
                return;
            }

            if (sortOrder.Data.ContainsKey(key))
            {
                sortOrder.Data[key] = newValue;
                logMessageCallback($"Value for key '{key}' updated to '{newValue}'.");
            }
            else
            {
                sortOrder.Data[key] = newValue;
                logMessageCallback($"Added key '{key}' with value '{newValue}' to sort order data.");
            }
        }


        public void BackupSortOrderJson(string filePath)
        {
            string backupPath = Path.ChangeExtension(filePath, ".bak");
            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            backupPath = $"{backupPath}_{timeStamp}";
            try
            {
                File.Copy(filePath, backupPath, true);
                logMessageCallback($"Backup created: {backupPath}");
            }
            catch (Exception ex)
            {
                logMessageCallback($"Error creating backup: {ex.Message}");
            }
        }

        public void WriteSortOrderToJson(string filePath, SortOrder sortOrder)
        {
            try
            {
                string jsonText = JsonConvert.SerializeObject(sortOrder, Newtonsoft.Json.Formatting.Indented);

                // Write the JSON content to the file using StreamWriter with UTF-8 encoding and BOM
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                using (var writer = new StreamWriter(stream, new UTF8Encoding(true))) // true parameter to include BOM
                {
                    writer.Write(jsonText);
                }

                logMessageCallback($"Sort order data updated and saved to: {filePath}");
            }
            catch (Exception ex)
            {
                logMessageCallback($"Error writing JSON file: {ex.Message}");
            }
        }

    }
}
