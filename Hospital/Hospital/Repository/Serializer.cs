using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    class Serializer<T> where T: Serializable, new()
    {
        private static string _delimiter = "|";
        public void toCSV(string fileName, List<T> objects) {
            StreamWriter streamWriter = new StreamWriter(fileName);

            foreach (Serializable obj in objects) {
                string line = string.Join(_delimiter, obj.ToCSV());
                streamWriter.WriteLine(line);
            }
        }

        public List<T> fromCSV(string fileName) {
            List<T> objects = new List<T>();

            foreach (string line in File.ReadLines(fileName)) {
                string[] csvValues = line.Split(Convert.ToChar(_delimiter));
                T obj = new T();
                obj.FromCSV(csvValues);
                objects.Add(obj);
            }

            return objects;
        }
    }
}
