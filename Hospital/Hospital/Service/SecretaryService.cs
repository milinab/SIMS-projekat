using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class SecretaryService
    {
        private int _id;
        public readonly SecretaryRepository _repository;
        public SecretaryService(SecretaryRepository secretaryRepository)
        {
            _repository = secretaryRepository;
            ObservableCollection<Secretary> secretaries = Read();
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

        public ObservableCollection<Secretary> Read()
        {
            return _repository.Read();
        }
    }
}