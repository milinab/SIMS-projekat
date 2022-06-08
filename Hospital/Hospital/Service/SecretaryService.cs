using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class SecretaryService
    {
        private int _id;
        private readonly SecretaryRepository _repository;
        public SecretaryService(SecretaryRepository secretaryRepository)
        {
            _repository = secretaryRepository;
            List<Secretary> secretaries = Read();
            if (secretaries.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = secretaries.Last().Id;
            }
        }
        public Secretary ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Secretary newSecretary)
        {
            newSecretary.Id = GenerateId();
            _repository.Create(newSecretary);
        }

        public void Edit(Secretary editSecretary)
        {
            _repository.Edit(editSecretary);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Secretary> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}