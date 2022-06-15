using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.AppointmentRepo;
using Hospital.Repository.TherapyRepo;

namespace Hospital.Repository.AnamnesisRepo
{
    public class AnamnesisRepository : IAnamnesisRepository
    {
        private readonly Serializer<Anamnesis> _serializer;
        private readonly TherapyRepository _therapyRepository;
        private readonly AppointmentRepository _appointmentRepository;

        public AnamnesisRepository(TherapyRepository therapyRepository, AppointmentRepository appointmentRepository)
        {
            _serializer = new Serializer<Anamnesis>("anamnesis.csv");
            _therapyRepository = therapyRepository;
            _appointmentRepository = appointmentRepository;
        }

        public List<Anamnesis> Read()
        {

            return _serializer.Read();
        }
        
        public Anamnesis ReadById(int id)
        {
            foreach (var anamnesis in Read())
            {
                if (anamnesis.Id != id) continue;
                var therapy = _therapyRepository.ReadById(anamnesis.TherapyId);
                var appointment = _appointmentRepository.ReadById(anamnesis.AppointmentId);
                if (therapy == null || appointment == null) continue;
                anamnesis.Therapy = therapy;
                anamnesis.Appointment = appointment;
                return anamnesis;
            }
            return null;
        }
        
        public void Create(Anamnesis newAnamnesis)
        {
            var list = Read();
            list.Add(newAnamnesis);
            Write(list);
        }
        
        public void Edit(Anamnesis editAnamnesis)
        {
            var list = Read();
            foreach (var anamnesis in list.Where(anamnesis => editAnamnesis.Id.Equals(anamnesis.Id)))
            {
                anamnesis.Diagnosis = editAnamnesis.Diagnosis;
                anamnesis.Referral = editAnamnesis.Referral;
                anamnesis.Therapy = editAnamnesis.Therapy;
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
        
        public void Write(List<Anamnesis> list)
        {
            _serializer.Write(list);
        }
        public Anamnesis ReadByAppointmentId(int appointmentId)
        {
            foreach (Anamnesis anamnesis in Read())
            {
                if (anamnesis.AppointmentId == appointmentId)
                {
                    Appointment appointment = _appointmentRepository.ReadById(anamnesis.AppointmentId);
                    Therapy therapy = _therapyRepository.ReadById(anamnesis.TherapyId);

                    if (appointment != null)
                    {
                        anamnesis.Appointment = appointment;
                    }
                    if (therapy != null)
                    {
                        anamnesis.Therapy = therapy;
                    }

                    return anamnesis;
                   
                }
            }

            return null;
            
        }
    }
}