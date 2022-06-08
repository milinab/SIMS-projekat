using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class TherapyService
    {
        private int _id;
        private readonly TherapyRepository _repository;

        public TherapyService(TherapyRepository therapyRepository)
        {
            _repository = therapyRepository;
            List<Therapy> therapies = Read();
            if (therapies.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = therapies.Last().Id;
            }
        }

        public Therapy ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public List<Therapy> ReadByPatientId(int patientId)
        {
            return _repository.ReadByPatientId(patientId);
        }

        public void Create(Therapy newTherapy)
        {
            newTherapy.Id = GenerateId();
            _repository.Create(newTherapy);
        }

        public void Edit(Therapy editTherapy)
        {
            _repository.Edit(editTherapy);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Therapy> Read()
        {
            return _repository.Read();
        }
        private int GenerateId()
        {
            return ++_id;
        }
    }
}