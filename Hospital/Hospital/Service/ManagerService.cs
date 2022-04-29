using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class ManagerService
    {
        private int _id;
        public readonly ManagerRepository _repository;
        public ManagerService(ManagerRepository managerRepository)
        {
            _repository = managerRepository;
            ObservableCollection<Manager> managers = Read();
            if (managers.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = managers.Last().Id;
            }
        }
        public Manager ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Manager newManager)
        {
            _repository.Create(newManager);
        }

        public void Edit(Manager editManager)
        {
            _repository.Edit(editManager);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<Manager> Read()
        {
            return _repository.Read();
        }
    }
}