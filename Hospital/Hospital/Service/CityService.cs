using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class CityService
    {
        private int _id;
        private readonly CityRepository _repository;

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
            newCity.Id = GenerateId();
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

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
