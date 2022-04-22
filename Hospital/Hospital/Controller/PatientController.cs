using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hospital.Model
{
    public class PatientController
    {
        private readonly PatientService _service;

        public PatientController(PatientService service)
        {
            _service = service;
        }
        public Patient ReadById(int id)
        {
            return _service.ReadById(id);
        }
      
        public void Create(Patient newPatient)
        {
            _service.Create(newPatient);
        }
      
        public void Edit(Patient newPatient)
        {
            _service.Edit(newPatient);
        }
      
        public void Delete(Patient newPatient)
        {
            _service.Delete(newPatient);
        }

        public ObservableCollection<Patient> ReadAll()
        {
            return _service.ReadAll();
        }
    }
}