using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class CityController
    {
        private readonly CityService _service;

        public CityController(CityService service)
        {
            _service = service;
        }

        public City ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(City newCity)
        {
            _service.Create(newCity);
        }

        public void Edit(City editCity)
        {
            _service.Edit(editCity);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<City> Read()
        {
            return _service.Read();
        }
    }
}
