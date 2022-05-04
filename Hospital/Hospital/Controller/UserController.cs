using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class UserController
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        public User ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(User newUser)
        {
            _service.Create(newUser);
        }

        public void Edit(User editUser)
        {
            _service.Edit(editUser);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<User> ReadAll()
        {
            return _service.Read();
        }

        public int FindId(string username)
        {
            return _service.FindId(username);
        }
        public (bool isValid, string type) IsLogInValid(string username, string password)
        {
            return _service.IsLogInValid(username, password);
        }
    }
}
