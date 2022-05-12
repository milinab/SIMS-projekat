using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class TrolService
    {
        private int _id;
        private readonly TrolRepository _repository;

        public TrolService(TrolRepository trolRepository)
        {
            _repository = trolRepository;
            ObservableCollection<Trol> trols = Read();
            if (trols.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = trols.Last().Id;
            }
        }

        public Trol ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Trol newTrol)
        {
            newTrol.Id = GenerateId();
            _repository.Create(newTrol);
        }

        public void Edit(Trol editTrol)
        {
            _repository.Edit(editTrol);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<Trol> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
        public Trol ReadByPatientId(int patientId)
        {
            return _repository.ReadByPatientId(patientId);
        }
    }
}
