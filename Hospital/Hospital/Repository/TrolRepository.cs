using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class TrolRepository
    {
        private ObservableCollection<Trol> _trols;
        private readonly Serializer<Trol> _serializer;
        private readonly TrolRepository _trolsRepository;

        public TrolRepository()
        {
            _serializer = new Serializer<Trol>("trols.csv");
            _trols = new ObservableCollection<Trol>();
        }

        public TrolRepository(TrolRepository trolRepository)
        {
            _serializer = new Serializer<Trol>("trols.csv");
            _trols = new ObservableCollection<Trol>();
            _trolsRepository = trolRepository;
        }

        public ObservableCollection<Trol> Read()
        {
            _trols = _serializer.Read();
            return _trols;
        }

        public Trol ReadById(int id)
        {
            foreach (Trol trol in _trols)
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
            _trols.Add(newTrol);
            Write();
        }

        public void Edit(Trol editTrol)
        {
            foreach (Trol trol in _trols)
            {
                if (editTrol.Id.Equals(trol.Id))
                {
                    trol.NumberOfCancellations = editTrol.NumberOfCancellations; 
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _trols.Count - 1; i >= 0; i--)
            {
                if (_trols[i].Id.Equals(id))
                {
                    _trols.Remove(_trols[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_trols);
        }

        public Trol ReadByPatientId(int patientId)
        {
            foreach (Trol trol in _trols)
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
