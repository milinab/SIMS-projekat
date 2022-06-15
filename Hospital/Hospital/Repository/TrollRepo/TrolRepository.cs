using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.TrollRepo
{
    public class TrolRepository : ITrolRepository
    {
        private readonly Serializer<Trol> _serializer;

        public TrolRepository()
        {
            _serializer = new Serializer<Trol>("trols.csv");
        }

        public List<Trol> Read()
        {
            return _serializer.Read();
        }

        public Trol ReadById(int id)
        {
            foreach (Trol trol in Read())
            {
                if (trol.Id.Equals(id))
                {
                    return trol;
                }
            }
            return null;
        }

        public void Create(Trol newTrol)
        {
            var list = Read();
            list.Add(newTrol);
            Write(list);
        }

        public void Edit(Trol editTrol)
        {
            var list = Read();
            foreach (Trol trol in list)
            {
                if (editTrol.Id.Equals(trol.Id))
                {
                    trol.NumberOfCancellations = editTrol.NumberOfCancellations; 
                }
            }
            Write(list);
        }

        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<Trol> list)
        {
            _serializer.Write(list);
        }

        public Trol ReadByPatientId(int patientId)
        {
            foreach (Trol trol in Read())
            {
                if (trol.PatientId.Equals(patientId))
                {
                    return trol;
                }
            }
            return null;
        }
    }
}
