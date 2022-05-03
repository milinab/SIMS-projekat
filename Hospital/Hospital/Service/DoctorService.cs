﻿using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class DoctorService
    {
        private int _id;
        private readonly DoctorRepository _repository;
        
        public DoctorService(DoctorRepository doctorRepository)
        {
            _repository = doctorRepository;
            ObservableCollection<Doctor> doctors = Read();
            if (doctors.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = doctors.Last().Id;
            }
        }
        public Doctor ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Doctor newDoctor)
        {
            newDoctor.Id = GenerateId();
            _repository.Create(newDoctor);
        }

        public void Edit(Doctor editDoctor)
        {
            _repository.Edit(editDoctor);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<Doctor> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }

    }
}