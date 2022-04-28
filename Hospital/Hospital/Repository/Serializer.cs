using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ObservableCollection<T> Read()
        {
            string csvText = File.ReadAllText(_dataPath);
            ObservableCollection<T> objects = csvText.FromCsv<ObservableCollection<T>>();
            return objects;
        }

        public void Write(ObservableCollection<T> objects)
        {
            string csvText = CsvSerializer.SerializeToCsv(objects);
            File.WriteAllText(_dataPath, csvText);
        }
    }
}
