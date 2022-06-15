using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.AddressRepository;
using Hospital.Repository.CityRepo;

namespace Hospital.Repository.AddressRepo
{
    public class AddressRepository : IAddressRepository
    {
        private readonly Serializer<Address> _serializer;
        private readonly CityRepository _cityRepository;

        public AddressRepository(CityRepository cityRepository)
        {
            _serializer = new Serializer<Address>("addresses.csv");
            _cityRepository = cityRepository;
        }

        public List<Address> Read()
        {
            return _serializer.Read();
        }

        public Address ReadById(int id)
        {
            foreach (var address in Read())
            {
                if (address.Id == id)
                {
                    City city = _cityRepository.ReadById(address.CityId);
                    if (city != null)
                    {
                        address.City = city;
                        return address;
                    }
                }
            }
            return null;
        }

        public void Create(Address newAddress)
        {
            var list = Read();
            list.Add(newAddress);
            Write(list);
        }

        public void Edit(Address editAddress)
        {
            var list = Read();
            foreach (Address address in list)
            {
                if (editAddress.Id.Equals(address.Id))
                {
                    address.City = editAddress.City;
                    address.Number = editAddress.Number;
                    address.Street = editAddress.Street;
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

        public void Write(List<Address> list)
        {
            _serializer.Write(list);
        }
    }
}
