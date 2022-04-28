using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class UserService
    {
        private int _id;
        public readonly UserRepository _userRepository;

        private readonly ObservableCollection<User> _users;

        public UserService(UserRepository userRepository)
        {
            _userRepository = new UserRepository();
            _users = _userRepository.Read();
            if (_users.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = _users.Last().Id;
            }
            _userRepository = userRepository;
        }

        public User ReadById(int id)
        {
            foreach (User user in _users)
            {
                if (user.Id.Equals(id))
                {
                    return user;
                }
            }
            return null;
        }

        public void Create(User newUser)
        {
            newUser.Id = GenerateID();
            _users.Add(newUser);
            Console.WriteLine(_users.Last().Id);
        }

        public void Edit(User editUser)
        {
            foreach (User user in _users)
            {
                if (user.Id.Equals(editUser.Id))
                {
                    user.Name = editUser.Name;
                    user.LastName = editUser.LastName;
                    user.IdNumber = editUser.IdNumber;
                    user.Username = editUser.Username;
                    user.Password = editUser.Password;
                    user.Address = editUser.Address;
                    user.Phone = editUser.Phone;
                    user.Email = editUser.Email;
                    user.AccountType = editUser.AccountType;
                    user.DateOfBirth = editUser.DateOfBirth;
                }
            }
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
        }

        public ObservableCollection<User> ReadAll()
        {
            return _users;
        }
        private int GenerateID()
        {
            return ++_id;
        }

        public (bool isValid, string type) IsLogInValid(string username, string password)
        {
            foreach (User user in _users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return (true, user.AccountType);
                }
            }
            return (false, "notype");
        } 
    }
}
