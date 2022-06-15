using System.Collections.Generic;
using Hospital.Model;

namespace Hospital.Repository.DoctorRepo
{
    public class DoctorRepository
    {
        private List<Doctor> _doctors;
        private readonly Serializer<Doctor> _serializer;
        public DoctorRepository()
        {
            _serializer = new Serializer<Doctor>("doctors.csv");
            _doctors = new List<Doctor>();
        }

        public List<Doctor> Read()
        {
            _doctors = _serializer.Read();
            return _doctors;
        }

        public Doctor ReadById(int id)
        {
            foreach (Doctor doctor in _doctors)
            {
                if (doctor.Id.Equals(id))
                {
                    return doctor;
                }
            }
            return null;
        }

        public void Create(Doctor newDoctor)
        {
            _doctors.Add(newDoctor);
            Write();
        }

        public void Edit(Doctor editDoctor)
        {
            foreach (Doctor doctor in _doctors)
            {
                if (doctor.Id.Equals(editDoctor.Id))
                { 
                    doctor.IdNumber = editDoctor.IdNumber;
                    doctor.LastName = editDoctor.LastName;
                    doctor.Name = editDoctor.Name;
                    doctor.Password = editDoctor.Password;
                    doctor.Phone = editDoctor.Phone;
                    doctor.Username = editDoctor.Username;
                    doctor.Address = editDoctor.Address;
                    doctor.DateOfBirth = editDoctor.DateOfBirth;
                    doctor.Email = editDoctor.Email;
                    doctor.Experience = editDoctor.Experience;
                    doctor.Vacation = editDoctor.Vacation;
                    doctor.Specialization = editDoctor.Specialization;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _doctors.Count - 1; i >= 0; i--)
            {
                if (_doctors[i].Id.Equals(id))
                {
                    _doctors.Remove(_doctors[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_doctors);
        }
    }
}