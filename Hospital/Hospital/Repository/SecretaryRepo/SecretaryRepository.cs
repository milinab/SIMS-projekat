using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository.SecretaryRepo
{
    public class SecretaryRepository : ISecretaryRepository
    {
        private List<Secretary> _secretaries;
        private readonly Serializer<Secretary> _serializer;
        public SecretaryRepository()
        {
            _serializer = new Serializer<Secretary>("secretaries.csv");
            _secretaries = new List<Secretary>();
        }

        public List<Secretary> Read()
        {
            _secretaries = _serializer.Read();
            return _secretaries;
        }

        public Secretary ReadById(int id)
        {
            foreach (Secretary secretary in _secretaries)
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
            _secretaries.Add(newSecretary);
            Write();
        }

        public void Edit(Secretary editSecretary)
        {
            foreach (Secretary secretary in _secretaries)
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
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _secretaries.Count - 1; i >= 0; i--)
            {
                if (_secretaries[i].Id.Equals(id))
                {
                    _secretaries.Remove(_secretaries[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_secretaries);
        }
    }
}