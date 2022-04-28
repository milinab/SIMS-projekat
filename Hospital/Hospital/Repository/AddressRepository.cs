using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.Repository
{
    public class AddressRepository
    {
        private ObservableCollection<Address> _addresses;
        private readonly Serializer<Address> _serializer;

        public AddressRepository()
        {
            _serializer = new Serializer<Address>("addresses.csv");
            _addresses = new ObservableCollection<Address>();
        }

        public ObservableCollection<Address> Read()
        {
            _addresses = _serializer.Read();
            return _addresses;
        }

        public Address ReadById(int id)
        {
            foreach (Address address in _addresses)
            {
                if (address.Id.Equals(id))
                {
                    return address;
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
