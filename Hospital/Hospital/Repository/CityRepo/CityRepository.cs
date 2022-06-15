using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.CountryRepo;

namespace Hospital.Repository.CityRepo
{
    public class CityRepository : ICityRepository
    {
        private readonly Serializer<City> _serializer;
        private readonly CountryRepository _countryRepository;

        public CityRepository(CountryRepository countryRepository)
        {
            _serializer = new Serializer<City>("cities.csv");
            _countryRepository = countryRepository;
        }

        public List<City> Read()
        {

            return _serializer.Read();
        }

        public City ReadById(int id)
        {
            foreach (var city in Read())
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
            var list = Read();
            list.Add(newCity);
            Write(list);
        }

        public void Edit(City editCity)
        {
            var list = Read();
            foreach (City city in list)
            {
                if (editCity.Id.Equals(city.Id))
                {
                    city.Country = editCity.Country;
                    city.Name = editCity.Name;
                    city.Zip = editCity.Zip;
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

        public void Write(List<City> list)
        {
            _serializer.Write(list);
        }
    }
}
