using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository.CountryRepo;

namespace Hospital.Repository.CityRepo
{
    public class CityRepository : ICityRepository
    {
        private List<City> _cities;
        private readonly Serializer<City> _serializer;
        private readonly CountryRepository _countryRepository;

        public CityRepository(CountryRepository countryRepository)
        {
            _serializer = new Serializer<City>("cities.csv");
            _cities = new List<City>();
            _countryRepository = countryRepository;
        }

        public List<City> Read()
        {
            _cities = _serializer.Read();
            foreach (var city in _cities)
            {
                Country country = _countryRepository.ReadById(city.CountryId);
                if (country != null)
                {
                    city.Country = country;
                }
            }
            return _cities;
        }

        public City ReadById(int id)
        {
            _cities = _serializer.Read();
            foreach (var city in _cities)
            {
                if (city.Id == id)
                {
                    Country country = _countryRepository.ReadById(city.CountryId);
                    if (country != null)
                    {
                        city.Country = country;
                        return city;
                    }
                }
            }
            return null;
        }

        public void Create(City newCity)
        {
            _cities.Add(newCity);
            Write();
        }

        public void Edit(City editCity)
        {
            foreach (City city in _cities)
            {
                if (editCity.Id.Equals(city.Id))
                {
                    city.Country = editCity.Country;
                    city.Name = editCity.Name;
                    city.Zip = editCity.Zip;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _cities.Count - 1; i >= 0; i--)
            {
                if (_cities[i].Id.Equals(id))
                {
                    _cities.Remove(_cities[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_cities);
        }
    }
}
