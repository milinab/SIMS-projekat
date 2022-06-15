using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.TherapyRepo
{
    public class TherapyRepository : ITherapyRepository
    {
        private readonly Serializer<Therapy> _serializer;

        public TherapyRepository()
        {
            _serializer = new Serializer<Therapy>("therapies.csv");
        }

        public List<Therapy> Read()
        {
            return _serializer.Read();
        }

        public Therapy ReadById(int id)
        {
            foreach (Therapy therapy in Read())
            {
                if (therapy.Id.Equals(id))
                {
                    return therapy;
                }
            }
            return null;
        }

        public List<Therapy> ReadByPatientId(int PatientId)
        {

            List<Therapy> result = new List<Therapy>(); 

            foreach (Therapy therapy in Read())
            {
                if (therapy.PatientId.Equals(PatientId))
                {
                    result.Add(therapy);

                }
            }
            return result;
        }

        public void Create(Therapy newTherapy)
        {
            var list = Read();
            list.Add(newTherapy);
            Write(list);
        }

        public void Edit(Therapy editTherapy)
        {
            var list = Read();
            foreach (Therapy therapy in list)
            {
                if (editTherapy.Id.Equals(therapy.Id))
                {
                    therapy.Medicine = editTherapy.Medicine;
                    therapy.Time = editTherapy.Time;
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

        public void Write(List<Therapy> list)
        {
            _serializer.Write(list);
        }
    }
}
