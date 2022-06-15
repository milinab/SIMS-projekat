using System;
using System.Collections.Generic;
using Hospital.Model;
using Hospital.Repository.DoctorRepo;
using Hospital.Repository.PatientRepo;
using Hospital.Repository.RoomRepo;

namespace Hospital.Repository.AppointmentRepo
{
   public class AppointmentRepository
   {
        private List<Appointment> _appointments;
        private readonly Serializer<Appointment> _serializer;
        private readonly DoctorRepository _doctorRepository;
        private readonly PatientRepository _patientRepository;
        private readonly RoomRepository _roomRepository;
        
        public AppointmentRepository(DoctorRepository doctorRepository, PatientRepository patientRepository, 
            RoomRepository roomRepository)
        {
            _serializer = new Serializer<Appointment>("appointments.csv");
            _appointments = new List<Appointment>();
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
        }

        public List<Appointment> Read()
        {
            _appointments = _serializer.Read();

            foreach (var appointment in _appointments)
            {
                Doctor doctor = _doctorRepository.ReadById(appointment.DoctorId);
                Patient patient = _patientRepository.ReadById(appointment.PatientId);
                Room room = _roomRepository.ReadById(appointment.RoomId);
                if (doctor != null)
                {
                    appointment.Doctor = doctor;
                }
                if (patient != null)
                {
                    appointment.Patient = patient;
                }
                if (room != null)
                {
                    appointment.Room = room;
                }
            }
            return _appointments;
        }

        public Appointment ReadById(int id)
        {
            _appointments = _serializer.Read();
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.Id == id)
                {
                    Doctor doctor = _doctorRepository.ReadById(appointment.DoctorId);
                    Patient patient = _patientRepository.ReadById(appointment.PatientId);
                    Room room = _roomRepository.ReadById(appointment.RoomId);
                    if (doctor != null)
                    {
                        appointment.Doctor = doctor;
                    }
                    if (patient != null)
                    {
                        appointment.Patient = patient;
                    }
                    if (room != null)
                    {
                        appointment.Room = room;
                    }
                    return appointment;
                }
            }
            return null;
        }

        public void Create(Appointment newAppointment)
        {
            _appointments.Add(newAppointment);
            Write();
        }

        public void Edit(Appointment editAppointment)
        {
            _appointments = _serializer.Read();
            foreach (Appointment appointment in _appointments)
            {
                if (editAppointment.Id == appointment.Id)
                {
                    appointment.Date = editAppointment.Date;
                    appointment.Duration = editAppointment.Duration;
                    appointment.Room = editAppointment.Room;
                    appointment.Patient = editAppointment.Patient;
                    appointment.Doctor = editAppointment.Doctor;
                    appointment.RoomId = editAppointment.RoomId;
                    appointment.PatientId = editAppointment.PatientId;
                    appointment.DoctorId = editAppointment.DoctorId;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _appointments.Count - 1; i >= 0; i--)
            {
                if (_appointments[i].Id.Equals(id))
                {
                    _appointments.Remove(_appointments[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_appointments);
        }
        public List<Appointment> ReadByDoctorId(int doctorId)
        {
            var itemsToReturn = new List<Appointment>();
            _appointments = _serializer.Read();
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.DoctorId == doctorId)
                {
                    Doctor doctor = _doctorRepository.ReadById(appointment.DoctorId);
                    Patient patient = _patientRepository.ReadById(appointment.PatientId);
                    Room room = _roomRepository.ReadById(appointment.RoomId);
                    if (doctor != null)
                    {
                        appointment.Doctor = doctor;
                    }
                    if (patient != null)
                    {
                        appointment.Patient = patient;
                    }
                    if (room != null)
                    {
                        appointment.Room = room;
                    }

                    itemsToReturn.Add(appointment);
                }
            }
            return itemsToReturn;
        }

        public List<Appointment> ReadByDateAndNotDoctor(int doctorId, DateTime date)
        {
            var itemsToReturn = new List<Appointment>();
            _appointments = _serializer.Read();
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.Date.Date == date && appointment.DoctorId != doctorId)
                {
                    
                    Doctor doctor = _doctorRepository.ReadById(appointment.DoctorId);
                    Patient patient = _patientRepository.ReadById(appointment.PatientId);
                    Room room = _roomRepository.ReadById(appointment.RoomId);
                    if (doctor != null)
                    {
                        appointment.Doctor = doctor;
                    }
                    if (patient != null)
                    {
                        appointment.Patient = patient;
                    }
                    if (room != null)
                    {
                        appointment.Room = room;
                    }
                    itemsToReturn.Add(appointment);
                    
                }
            }
            return itemsToReturn;
        }

        public List<Appointment> ReadByPatientId(int patientId)
        {
            var itemsToReturn = new List<Appointment>();
            _appointments = _serializer.Read();
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.PatientId == patientId)
                {
                    Doctor doctor = _doctorRepository.ReadById(appointment.DoctorId);
                    Patient patient = _patientRepository.ReadById(appointment.PatientId);
                    Room room = _roomRepository.ReadById(appointment.RoomId);
                    if (doctor != null)
                    {
                        appointment.Doctor = doctor;
                    }
                    if (patient != null)
                    {
                        appointment.Patient = patient;
                    }
                    if (room != null)
                    {
                        appointment.Room = room;
                    }
                    itemsToReturn.Add(appointment);
                }
            }
            return itemsToReturn;
        }
    }
}