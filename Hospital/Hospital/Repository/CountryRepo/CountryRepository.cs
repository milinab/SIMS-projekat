using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository.CountryRepo
{
    public class CountryRepository : ICountryRepository
    {
        private List<Country> _countries;
        private readonly Serializer<Country> _serializer;

        public CountryRepository()
        {
            _serializer = new Serializer<Country>("countries.csv");
            _countries = new List<Country>();
        }

        public List<Country> Read()
        {
            _countries = _serializer.Read();
            return _countries;
        }

        public Country ReadById(int id)
        {
            foreach (Country country in _countries)
            {
                if (country.Id.Equals(id))
                {
                    return country;
                }
            }
            return null;
        }

        public void Create(Country newCountry)
        {
            _countries.Add(newCountry);
            Write();
        }

        public void Edit(Country editCountry)
        {
            foreach (Country country in _countries)
            {
                if (editCountry.Id.Equals(country.Id))
                {
                    country.Name = editCountry.Name;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _countries.Count - 1; i >= 0; i--)
            {
                if (_countries[i].Id.Equals(id))
                {
                    _countries.Remove(_countries[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_countries);
        }
    }
}
