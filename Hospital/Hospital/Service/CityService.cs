using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class CityService
    {
        private int _id;
        public readonly CityRepository _repository;

        public CityService(CityRepository cityRepository)
        {
            _repository = cityRepository;
            ObservableCollection<City> cities = Read();
            if (cities.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = cities.Last().Id;
            }
        }

        public City ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(City newCity)
        {
            newCity.Id = GenerateID();
            _repository.Create(newCity);
        }

        public void Edit(City editCity)
        {
            _repository.Edit(editCity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<City> Read()
        {
            return _repository.Read();
        }

        private int GenerateID()
        {
            return ++_id;
        }
    }
}
