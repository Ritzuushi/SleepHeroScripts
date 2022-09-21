using System.IO;
using UnityEngine;

namespace RStudio.Utils.JsonFileSystem
{
    public class Load
    {
        public void Persistent(object jsonObject, string fileName)
        {
            var filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");

            if (!File.Exists(filePath)) return;

            using (StreamReader sr = new StreamReader(filePath))
            {
                JsonUtility.FromJsonOverwrite(sr.ReadToEnd(), jsonObject);
                sr.Close();
            }
        }

        public T Persistent<T>(string fileName)
        {
            var filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");

            if (!File.Exists(filePath)) return default(T);

            using (StreamReader sr = new StreamReader(filePath))
            {
                var jsonObject = JsonUtility.FromJson<T>(sr.ReadToEnd());
                sr.Close();
                return jsonObject;
            }
        }

        public void Temporary(object jsonObject, string fileName)
        {
            var filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");

            if (!File.Exists(filePath)) return;

            using (StreamReader sr = new StreamReader(filePath))
            {
                JsonUtility.FromJsonOverwrite(sr.ReadToEnd(), jsonObject);
                File.Delete(filePath);
                sr.Close();
            }
        }
    }
}

