using UnityEngine;

namespace RStudio.Utils.JsonFileSystem
{
    public class JsonFileManager
    {
        private static Save _save = new Save();
        public static Save Save => _save;

        private static Load _load = new Load();
        public static Load Load => _load;
    }
}

