using System;
using System.Collections.ObjectModel;
using System.Windows;
using Hospital.Model;

namespace Hospital.Repository
{
   public class AppointmentRepository
   {
        private ObservableCollection<Appointment> _appointments;
        private readonly Serializer<Appointment> _serializer;
        private readonly DoctorRepository _doctorRepository;
        private readonly PatientRepository _patientRepository;
        private readonly RoomRepository _roomRepository;
        
        public AppointmentRepository(DoctorRepository doctorRepository, PatientRepository patientRepository, 
            RoomRepository roomRepository)
        {
            _serializer = new Serializer<Appointment>("appointments.csv");
            _appointments = new ObservableCollection<Appointment>();
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
        }

        public ObservableCollection<Appointment> Read()
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
        public ObservableCollection<Appointment> ReadByDoctorId(int doctorId)
        {
            var itemsToReturn = new ObservableCollection<Appointment>();
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

        public ObservableCollection<Appointment> ReadByDateAndNotDoctor(int doctorId, DateTime date)
        {
            var itemsToReturn = new ObservableCollection<Appointment>();
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
    }
}