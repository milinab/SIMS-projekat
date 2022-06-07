using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class TherapyRepository
    {
        private ObservableCollection<Therapy> _therapies;
        private readonly Serializer<Therapy> _serializer;

        public TherapyRepository()
        {
            _serializer = new Serializer<Therapy>("therapies.csv");
            _therapies = new ObservableCollection<Therapy>();
        }

        public ObservableCollection<Therapy> Read()
        {
            _therapies = _serializer.Read();
            return _therapies;
        }

        public Therapy ReadById(int id)
        {
            foreach (Therapy therapy in _therapies)
            {
                if (therapy.Id.Equals(id))
                {
                    return therapy;
                }
            }
            return null;
        }

        public ObservableCollection<Therapy> ReadByPatientId(int PatientId)
        {
            foreach (Therapy therapy in _therapies)
            {
                if (therapy.PatientId.Equals(PatientId))
                {
                    _therapies.Add(therapy);

                }
            }
            return _therapies;
        }

        public void Create(Therapy newTherapy)
        {
            _therapies.Add(newTherapy);
            Write();
        }

        public void Edit(Therapy editTherapy)
        {
            foreach (Therapy therapy in _therapies)
            {
                if (editTherapy.Id.Equals(therapy.Id))
                {
                    therapy.Medicine = editTherapy.Medicine;
                    therapy.Time = editTherapy.Time;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _therapies.Count - 1; i >= 0; i--)
            {
                if (_therapies[i].Id.Equals(id))
                {
                    _therapies.Remove(_therapies[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_therapies);
        }
    }
}
