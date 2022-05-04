using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
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

        public Patient ReadByIdTest(int id)
        {
            return _service.ReadByIdTest(id);
        }

        public void Create(Patient newPatient)
        {
            _service.Create(newPatient);
        }
      
        public void Edit(Patient editPatient)
        {
            _service.Edit(editPatient);
        }
      
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Patient> Read()
        {
            return _service.Read();
        }
    }
}