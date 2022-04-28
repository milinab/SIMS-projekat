using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.Repository
{
    public class UserRepository
    {
        private ObservableCollection<User> _users;
        private Serializer<User> _serializer;

        public UserRepository()
        {
            _serializer = new Serializer<User>("users.csv");
            _users = new ObservableCollection<User>();
        }

        public ObservableCollection<User> Read()
        {
            _users = _serializer.Read();
            return _users;
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
