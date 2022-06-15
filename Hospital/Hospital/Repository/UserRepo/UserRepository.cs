using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository.UserRepo
{
    public class UserRepository
    {
        private List<User> _users;
        private readonly Serializer<User> _serializer;
        private List<Address> _addresses;
        private readonly AddressRepository _addressRepository;

        public UserRepository(AddressRepository addressRepository)
        {
            _serializer = new Serializer<User>("users.csv");
            _users = new List<User>();
            _addresses = new List<Address>();
            _addressRepository = addressRepository;
        }

        public List<User> Read()
        {
            _users = _serializer.Read();

            foreach (var user in _users)
            {
                Address address = _addressRepository.ReadById(user.AddressId);
                if(address != null)
                {
                    user.Address = address;
                }
            }
            return _users;
        }

        public User ReadById(int id)
        {
            _users = _serializer.Read();
            foreach (User user in _users)
            {
                if (user.Id == id)
                {
                    Address address = _addressRepository.ReadById(user.AddressId);
                    if( address != null)
                    {
                        user.Address = address;
                        return user;
                    }
                    return user;
                }
            }
            return null;
        }

        public void Create(User newUser)
        {
            _users.Add(newUser);
            Write();
        }

        public void Edit(User editUser)
        {
            foreach (User user in _users)
            {
                if (editUser.Id.Equals(user.Id))
                {
                    user.IdNumber = editUser.IdNumber;
                    user.LastName = editUser.LastName;
                    user.Name = editUser.Name;
                    user.Password = editUser.Password;
                    user.Phone = editUser.Phone;
                    user.Username = editUser.Username;
                    user.Address = editUser.Address;
                    user.DateOfBirth = editUser.DateOfBirth;
                    user.Email = editUser.Email;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _users.Count - 1; i >= 0; i--)
            {
                if (_users[i].Id.Equals(id))
                {
                    _users.Remove(_users[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_users);
        }
    }
}
