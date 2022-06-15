using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.DoctorRepo;

namespace Hospital.Repository.VacationRepo
{
    public class VacationRepository : IVacationRepository
    {
        private readonly Serializer<Vacation> _serializer;
        private readonly DoctorRepository _doctorRepository;

        public VacationRepository(DoctorRepository doctorRepository)
        {
            _serializer = new Serializer<Vacation>("vacations.csv");
            _doctorRepository = doctorRepository;
        }

        public List<Vacation> Read()
        {
            var list = _serializer.Read().ToList();
            foreach (var vacation in list)
            {
                var doctor = _doctorRepository.ReadById(vacation.DoctorId);
                if (doctor == null) continue;
                vacation.Doctor = doctor;
            }
            
            return list;
        }

        public Vacation ReadById(int id)
        {
            var list = _serializer.Read().ToList();
            return list.FirstOrDefault(vacation => vacation.Id == id);
        }

        public void Create(Vacation newVacation)
        {
            var list = Read();
            list.Add(newVacation);
            Write(list);
        }

        public void Edit(Vacation editVacation)
        {
            var list = Read();
            foreach (Vacation vacation in list)
            {
                if (editVacation.Id.Equals(vacation.Id))
                {
                    vacation.StartDate = editVacation.StartDate;
                    vacation.EndDate = editVacation.EndDate;
                    vacation.Reason = editVacation.Reason;
                    vacation.Doctor = editVacation.Doctor;
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

        public void Write(List<Vacation>list)
        {
            _serializer.Write(list);
        }
    }
}