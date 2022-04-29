using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Repository;

namespace Hospital.Model
{
    public class ManagerRepository
    {
        private ObservableCollection<Manager> _managers;
        private readonly Serializer<Manager> _serializer;
        public ManagerRepository()
        {
            _serializer = new Serializer<Manager>("managers.csv");
            _managers = new ObservableCollection<Manager>();
        }

        public ObservableCollection<Manager> Read()
        {
            _managers = _serializer.Read();
            return _managers;
        }

        public Manager ReadById(int id)
        {
            foreach (Manager manager in _managers)
            {
                if (manager.Id.Equals(id))
                {
                    return manager;
                }
            }
            return null;
        }

        public void Create(Manager newManager)
        {
            _managers.Add(newManager);
            Write();
        }

        public void Edit(Manager editManager)
        {
            foreach (Manager manager in _managers)
            {
                if (manager.Id.Equals(editManager.Id))
                {
                    manager.IdNumber = editManager.IdNumber;
                    manager.LastName = editManager.LastName;
                    manager.Name = editManager.Name;
                    manager.Password = editManager.Password;
                    manager.Phone = editManager.Phone;
                    manager.Username = editManager.Username;
                    manager.Address = editManager.Address;
                    manager.DateOfBirth = editManager.DateOfBirth;
                    manager.Email = editManager.Email;
                    manager.Experience = editManager.Experience;
                    manager.Vacation = editManager.Vacation;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _managers.Count - 1; i >= 0; i--)
            {
                if (_managers[i].Id.Equals(id))
                {
                    _managers.Remove(_managers[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_managers);
        }
    }
}