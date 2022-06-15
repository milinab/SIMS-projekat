using System.Collections.Generic;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.DoctorRepo
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly Serializer<Doctor> _serializer;
        public DoctorRepository()
        {
            _serializer = new Serializer<Doctor>("doctors.csv");
        }

        public List<Doctor> Read()
        {
            return _serializer.Read();
        }

        public Doctor ReadById(int id)
        {
            foreach (Doctor doctor in Read())
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
            var list = Read();
            list.Add(newDoctor);
            Write(list);
        }

        public void Edit(Doctor editDoctor)
        {
            var list = Read();
            foreach (Doctor doctor in list)
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
            Write(list);
        }

        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<Doctor> list)
        {
            _serializer.Write(list);
        }
    }
}