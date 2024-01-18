namespace xivmodimage
{
    public class AdvancedModProcessor
    {
        private List<ModInfo> modBatch;
        private int currentModIndex;

        public AdvancedModProcessor(List<ModInfo> mods)
        {
            modBatch = new List<ModInfo>(mods);
            currentModIndex = 0;
        }

        public ModInfo GetCurrentMod()
        {
            return currentModIndex < modBatch.Count ? modBatch[currentModIndex] : null;
        }

        public bool MoveToNextMod()
        {
            currentModIndex++;
            return currentModIndex < modBatch.Count;
        }
    }
}
