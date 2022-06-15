using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository.CityRepo;

namespace Hospital.Repository.AddressRepo
{
    public class AddressRepository
    {
        private List<Address> _addresses;
        private readonly Serializer<Address> _serializer;
        private readonly CityRepository _cityRepository;

        public AddressRepository(CityRepository cityRepository)
        {
            _serializer = new Serializer<Address>("addresses.csv");
            _addresses = new List<Address>();
            _cityRepository = cityRepository;
        }

        public List<Address> Read()
        {
            _addresses = _serializer.Read();
            
            foreach (var address in _addresses)
            {
                City city = _cityRepository.ReadById(address.CityId);
                if (city != null)
                {
                    address.City = city;
                }
            }
            return _addresses;
        }

        public Address ReadById(int id)
        {
            foreach (var address in _addresses)
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
            _addresses.Add(newAddress);
            Write();
        }

        public void Edit(Address editAddress)
        {
            foreach (Address address in _addresses)
            {
                if (editAddress.Id.Equals(address.Id))
                {
                    address.City = editAddress.City;
                    address.Number = editAddress.Number;
                    address.Street = editAddress.Street;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _addresses.Count - 1; i >= 0; i--)
            {
                if (_addresses[i].Id.Equals(id))
                {
                    _addresses.Remove(_addresses[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_addresses);
        }
    }
}
