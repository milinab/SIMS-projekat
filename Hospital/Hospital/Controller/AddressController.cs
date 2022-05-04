using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class AddressController
    {
        private readonly AddressService _service;

        public AddressController(AddressService service)
        {
            _service = service;
        }

        public Address ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Address newAddress)
        {
            _service.Create(newAddress);
        }

        public void Edit(Address editAddress)
        {
            _service.Edit(editAddress);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Address> Read()
        {
            return _service.Read();
        }
    }
}
