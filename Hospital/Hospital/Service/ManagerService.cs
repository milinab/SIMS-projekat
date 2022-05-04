using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class ManagerService
    {
        private int _id;
        private readonly ManagerRepository _repository;
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

        public ObservableCollection<Manager> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }
    }
}