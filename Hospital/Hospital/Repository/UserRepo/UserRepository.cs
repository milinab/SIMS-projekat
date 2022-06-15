using System.Collections.Generic;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly Serializer<User> _serializer;
        private readonly AddressRepo.AddressRepository _addressRepository;

        public UserRepository(AddressRepo.AddressRepository addressRepository)
        {
            _serializer = new Serializer<User>("users.csv");
            _addressRepository = addressRepository;
        }

        public List<User> Read()
        {
            var list = Read();
            foreach (var user in list)
            {
                Address address = _addressRepository.ReadById(user.AddressId);
                if(address != null)
                {
                    user.Address = address;
                }
            }
            return list;
        }

        public User ReadById(int id)
        {
            foreach (User user in Read())
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
            var list = Read();
            list.Add(newUser);
            Write(list);
        }

        public void Edit(User editUser)
        {
            var list = Read();
            foreach (User user in list)
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

        public void Write(List<User> list)
        {
            _serializer.Write(list);
        }
    }
}
