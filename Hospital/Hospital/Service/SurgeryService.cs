using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class SurgeryService
    {
        private int _id;
        public readonly SurgeryRepository _repository;

        public SurgeryService(SurgeryRepository surgeryRepository)
        {
            _repository = surgeryRepository;
            ObservableCollection<Surgery> surgeries = Read();
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
            newSurgery.Id = GenerateID();
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

        public ObservableCollection<Surgery> Read()
        {
            return _repository.Read();
        }
        private int GenerateID()
        {
            return ++_id;
        }
    }
}