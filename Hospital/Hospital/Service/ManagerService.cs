using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.ManagerRepo;

namespace Hospital.Service
{
    public class ManagerService
    {
        private int _id;
        private readonly IManagerRepository _repository;
        public ManagerService(IManagerRepository managerRepository)
        {
            _repository = managerRepository;
            List<Manager> managers = Read();
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
            newManager.Id = GenerateId();
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

        public List<Manager> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}