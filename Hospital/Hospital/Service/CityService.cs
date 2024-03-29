﻿using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.CityRepo;

namespace Hospital.Service
{
    public class CityService
    {
        private int _id;
        private readonly ICityRepository _repository;

        public CityService(ICityRepository cityRepository)
        {
            _repository = cityRepository;
            List<City> cities = Read();
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

        public List<City> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
