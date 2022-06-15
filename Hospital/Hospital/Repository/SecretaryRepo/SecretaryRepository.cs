using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.SecretaryRepo
{
    public class SecretaryRepository : ISecretaryRepository
    {
        private readonly Serializer<Secretary> _serializer;
        public SecretaryRepository()
        {
            _serializer = new Serializer<Secretary>("secretaries.csv");
        }

        public List<Secretary> Read()
        {
            return _serializer.Read();
        }

        public Secretary ReadById(int id)
        {
            foreach (Secretary secretary in Read())
            {
                if (secretary.Id.Equals(id))
                {
                    return secretary;
                }
            }
            return null;
        }

        public void Create(Secretary newSecretary)
        {
            var list = Read();
            list.Add(newSecretary);
            Write(list);
        }

        public void Edit(Secretary editSecretary)
        {
            var list = Read();
            foreach (Secretary secretary in list)
            {
                if (secretary.Id.Equals(editSecretary.Id))
                {
                    secretary.IdNumber = editSecretary.IdNumber;
                    secretary.LastName = editSecretary.LastName;
                    secretary.Name = editSecretary.Name;
                    secretary.Password = editSecretary.Password;
                    secretary.Phone = editSecretary.Phone;
                    secretary.Username = editSecretary.Username;
                    secretary.Address = editSecretary.Address;
                    secretary.DateOfBirth = editSecretary.DateOfBirth;
                    secretary.Email = editSecretary.Email;
                    secretary.Experience = editSecretary.Experience;
                    secretary.Vacation = editSecretary.Vacation;
                }
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

        public void Write(List<Secretary> list)
        {
            _serializer.Write(list);
        }
    }
}