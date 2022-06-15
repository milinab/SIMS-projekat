using System;
using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.DoctorRepo;
using Hospital.Repository.PatientRepo;
using Hospital.Repository.RoomRepo;

namespace Hospital.Repository.AppointmentRepo
{
   public class AppointmentRepository : IAppointmentRepository
   {
        private readonly Serializer<Appointment> _serializer;
        private readonly DoctorRepository _doctorRepository;
        private readonly PatientRepository _patientRepository;
        private readonly RoomRepository _roomRepository;
        
        public AppointmentRepository(DoctorRepository doctorRepository, PatientRepository patientRepository, 
            RoomRepository roomRepository)
        {
            _serializer = new Serializer<Appointment>("appointments.csv");
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
        }

        public List<Appointment> Read()
        {
            var list = _serializer.Read();

            foreach (var appointment in list)
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
            return list;
        }

        public Appointment ReadById(int id)
        {
            foreach (Appointment appointment in Read())
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
            var list = Read();
            list.Add(newAppointment);
            Write(list);
        }

        public void Edit(Appointment editAppointment)
        {
            var list = _serializer.Read();
            foreach (var appointment in list.Where(appointment => editAppointment.Id == appointment.Id))
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

        public void Write(List<Appointment> list)
        {
            _serializer.Write(list);
        }
        public List<Appointment> ReadByDoctorId(int doctorId)
        {
            var itemsToReturn = new List<Appointment>();
            foreach (Appointment appointment in Read())
            {
                if (appointment.DoctorId != doctorId)
                {
                    continue;
                }

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
            return itemsToReturn;
        }

        public List<Appointment> ReadByDateAndNotDoctor(int doctorId, DateTime date)
        {
            var itemsToReturn = new List<Appointment>();
            foreach (Appointment appointment in Read())
            {
                if (appointment.Date.Date != date || appointment.DoctorId == doctorId)
                {
                    continue;
                }

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
            return itemsToReturn;
        }

        public List<Appointment> ReadByPatientId(int patientId)
        {
            var itemsToReturn = new List<Appointment>();
            foreach (Appointment appointment in Read())
            {
                if (appointment.PatientId != patientId)
                {
                    continue;
                }

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
            return itemsToReturn;
        }
    }
}