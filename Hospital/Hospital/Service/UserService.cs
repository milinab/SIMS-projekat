using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class UserService
    {
        private int _id;
        private readonly UserRepository _repository;

        public UserService(UserRepository userRepository)
        {
            _repository = userRepository;
            ObservableCollection<User> users = Read();
            if (users.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = users.Last().Id;
            }
        }

        public User ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(User newUser)
        {
            newUser.Id = GenerateId();
            _repository.Create(newUser);
        }

        public void Edit(User editUser)
        {
            _repository.Edit(editUser);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<User> Read()
        {
            return _repository.Read();
        }
        private int GenerateId()
        {
            return ++_id;
        }
        
        public int FindId(string username)
        {
            foreach (User user in _repository.Read())
            {
                if (user.Username == username)
                {
                    return user.Id;
                }
            }
            return -1;
        }


        public (bool isValid, string type) IsLogInValid(string username, string password)
        {
            ObservableCollection<User> users = Read();
            foreach (User user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    return (true, user.AccountType);
                }
            }
            return (false, "notype");
        }

        public User GetLoggedUser(string username, string password)
        {
            ObservableCollection<User> users = Read();
            return users.FirstOrDefault(user => user.Username.Equals(username) && user.Password.Equals(password));
        }
    }
}
