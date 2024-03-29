﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.TrollRepo;

namespace Hospital.Service
{
    public class TrolService
    {
        private int _id;
        private readonly ITrolRepository _repository;

        public TrolService(ITrolRepository trolRepository)
        {
            _repository = trolRepository;
            List<Trol> trols = Read();
            if (trols.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = trols.Last().Id;
            }
        }

        public Trol ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Trol newTrol)
        {
            newTrol.Id = GenerateId();
            _repository.Create(newTrol);
        }

        public void Edit(Trol editTrol)
        {
            _repository.Edit(editTrol);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Trol> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
        public Trol ReadByPatientId(int patientId)
        {
            return _repository.ReadByPatientId(patientId);
        }
    }
}
