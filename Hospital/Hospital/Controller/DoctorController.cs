﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class DoctorController
    {
        private readonly DoctorService _service;

        public DoctorController(DoctorService service)
        {
            _service = service;
        }

        public Doctor ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Doctor newDoctor)
        {
            _service.Create(newDoctor);
        }

        public void Edit(Doctor editDoctor)
        {
            _service.Edit(editDoctor);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Doctor> Read()
        {
            return _service.Read();
        }
    }
}