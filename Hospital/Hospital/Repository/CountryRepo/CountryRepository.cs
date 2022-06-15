using System.Collections.Generic;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.CountryRepo
{
    public class CountryRepository : ICountryRepository
    {
        private readonly Serializer<Country> _serializer;

        public CountryRepository()
        {
            _serializer = new Serializer<Country>("countries.csv");
        }

        public List<Country> Read()
        {
            return _serializer.Read();
        }

        public Country ReadById(int id)
        {
            foreach (Country country in Read())
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
            var list = Read();
            list.Add(newCountry);
            Write(list);
        }

        public void Edit(Country editCountry)
        {
            var list = Read();
            foreach (var country in list.Where(country => editCountry.Id.Equals(country.Id)))
            {
                country.Name = editCountry.Name;
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

        public void Write(List<Country> list)
        {
            _serializer.Write(list);
        }
    }
}
