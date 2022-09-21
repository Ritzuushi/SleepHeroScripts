using System.IO;
using UnityEngine;

namespace RStudio.Utils.JsonFileSystem
{
    public class Save
    {
        public void Persistent(string jsonText, string fileName)
        {
            var filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(jsonText);
                sw.Close();
            }
        }

        public void Temporary(string jsonText, string fileName)
        {
            var filePath = Path.Combine(Application.temporaryCachePath, fileName + ".json");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(jsonText);
                sw.Close();
            }
        }
    }
}

