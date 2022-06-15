using System.Collections.Generic;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.ManagerRepo
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly Serializer<Manager> _serializer;
        public ManagerRepository()
        {
            _serializer = new Serializer<Manager>("managers.csv");
        }

        public List<Manager> Read()
        {
            return _serializer.Read();
        }

        public Manager ReadById(int id)
        {
            return Read().FirstOrDefault(manager => manager.Id.Equals(id));
        }

        public void Create(Manager newManager)
        {
            var list = Read();
            list.Add(newManager);
            Write(list);
        }

        public void Edit(Manager editManager)
        {
            var list = Read();
            foreach (var manager in list.Where(manager => manager.Id.Equals(editManager.Id)))
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
            Write(list);
        }

        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<Manager> list)
        {
            _serializer.Write(list);
        }
    }
}