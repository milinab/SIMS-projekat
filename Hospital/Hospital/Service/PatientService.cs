using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class PatientService
    {
        private int _id;
        private readonly PatientRepository _repository;
        public PatientService(PatientRepository patientRepository)
        {
            _repository = patientRepository;
            ObservableCollection<Patient> patients = Read();
            if (patients.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = patients.Last().Id;
            }
        }
        public Patient ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public Patient ReadByIdTest(int id)
        {
            return _repository.ReadByIdTest(id);
        }

        public void Create(Patient newPatient)
        {
            newPatient.Id = GenerateId();
            _repository.Create(newPatient);
        }
      
        public void Edit(Patient editPatient)
        {
            _repository.Edit(editPatient);
        }
      
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ObservableCollection<Patient> Read()
        {
            return _repository.Read();
        }
        
        private int GenerateId()
        {
            return ++_id;
        }

        public Patient ReadByUsername(string username)
        {
            return _repository.ReadByUsername(username);
        }
    }
}