using Hospital.Repository;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using System.Collections.Generic;

namespace Hospital.Service
{
    public class SurgeryService
    {
        private int _id;
        private readonly SurgeryRepository _repository;

        public SurgeryService(SurgeryRepository surgeryRepository)
        {
            _repository = surgeryRepository;
            List<Surgery> surgeries = Read();
            if (surgeries.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = surgeries.Last().Id;
            }
        }

        public Surgery ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Surgery newSurgery)
        {
            newSurgery.Id = GenerateId();
            _repository.Create(newSurgery);
        }

        public void Edit(Surgery editSurgery)
        {
            _repository.Edit(editSurgery);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Surgery> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}