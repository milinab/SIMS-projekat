using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ServiceStack;
using ServiceStack.Text;

namespace Hospital.Repository
{
    public class Serializer<T>
    {
        private readonly string _projectPath = AppContext.BaseDirectory + ".." + Path.DirectorySeparatorChar + ".." + Path.DirectorySeparatorChar+ "Resources"
            + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar;
        private readonly string _dataPath;

        public Serializer(string dataPath)
        {
            _dataPath = _projectPath + dataPath;
        }

        public List<T> Read()
        {
            string csvText = File.ReadAllText(_dataPath);
            List<T> objects = csvText.FromCsv<List<T>>();
            return objects;
        }

        public void Write(List<T> objects)
        {
            string csvText = CsvSerializer.SerializeToCsv(objects);
            File.WriteAllText(_dataPath, csvText);
        }
    }
}
