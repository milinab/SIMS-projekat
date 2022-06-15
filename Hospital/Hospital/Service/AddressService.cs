using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.AddressRepository;

namespace Hospital.Service
{
    public class AddressService
    {
        private int _id;
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository addressRepository)
        {
            _repository = addressRepository;
            List<Address> addresses = Read();
            if (addresses.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = addresses.Last().Id;
            }
        }

        public Address ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Address newAddress)
        {
            newAddress.Id = GenerateId();
            _repository.Create(newAddress);
        }

        public void Edit(Address editAddress)
        {
            _repository.Edit(editAddress);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Address> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
