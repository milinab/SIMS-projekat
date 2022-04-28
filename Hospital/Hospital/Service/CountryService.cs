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
    public class CountryService
    {
        private int _id;
        public readonly CountryRepository _repository;

        public CountryService(CountryRepository countryRepository)
        {
            _repository = countryRepository;
            ObservableCollection<Country> countries = Read();
            if (countries.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = countries.Last().Id;
            }
        }

        public Country ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Country newCountry)
        {
            newCountry.Id = GenerateID();
            _repository.Create(newCountry);
        }

        public void Edit(Country editCountry)
        {
            _repository.Edit(editCountry);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<Country> Read()
        {
            return _repository.Read();
        }

        private int GenerateID()
        {
            return ++_id;
        }
    }
}
