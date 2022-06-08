using System.Collections.Generic;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class CountryController
    {
        private readonly CountryService _service;

        public CountryController(CountryService service)
        {
            _service = service;
        }

        public Country ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Country newCountry)
        {
            _service.Create(newCountry);
        }

        public void Edit(Country editCountry)
        {
            _service.Edit(editCountry);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public List<Country> Read()
        {
            return _service.Read();
        }
    }
}
