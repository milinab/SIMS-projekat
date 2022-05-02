using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class PatientRepository
    {
        private ObservableCollection<Patient> _patients;
        private readonly Serializer<Patient> _serializer;
        private readonly AddressRepository _addressRepository;
   
        
        public PatientRepository(AddressRepository addressRepository)
        {
            _serializer = new Serializer<Patient>("patients.csv");
            _patients = new ObservableCollection<Patient>();
            _addressRepository = addressRepository;
        }

        public ObservableCollection<Patient> Read()
        {
            _patients = _serializer.Read();
            
            foreach (var patient in _patients)
            {
                Address address = _addressRepository.ReadById(patient.AddressId);
                if (address != null)
                {
                    patient.Address = address;
                }
            }
            return _patients;
        }

        public Patient ReadById(int id)
        {
            _patients = _serializer.Read();
            foreach (var patient in _patients)
            {
                if (patient.Id == id)
                {
                    Address address = _addressRepository.ReadById(patient.AddressId);
                    if (address != null)
                    {
                        patient.Address = address;
                        return patient;
                    }
                }
            }
            return null;
        }

        public void Create(Patient newPatient)
        {
            _patients.Add(newPatient);
            Write();
        }

        public void Edit(Patient editPatient)
        {
            foreach (Patient patient in _patients)
            {
                if (patient.Id.Equals(editPatient.Id))
                {
                    patient.HealthInsuranceId = editPatient.HealthInsuranceId;
                    patient.IdNumber = editPatient.IdNumber;
                    patient.LastName = editPatient.LastName;
                    patient.MedicalRecord = editPatient.MedicalRecord;
                    patient.Name = editPatient.Name;
                    patient.Password = editPatient.Password;
                    patient.Phone = editPatient.Phone;
                    patient.Username = editPatient.Username;
                    patient.Address = editPatient.Address;
                    patient.BloodType = editPatient.BloodType;
                    patient.DateOfBirth = editPatient.DateOfBirth;
                    patient.Email = editPatient.Email;
                    patient.Gender = editPatient.Gender;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _patients.Count - 1; i >= 0; i--)
            {
                if (_patients[i].Id.Equals(id))
                {
                    _patients.Remove(_patients[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_patients);
        }
    }
}