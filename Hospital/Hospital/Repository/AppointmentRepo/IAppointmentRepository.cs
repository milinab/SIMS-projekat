using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.AppointmentRepo
{
    public interface IAppointmentRepository : IRepositoryBase<Appointment, int>
    {
        List<Appointment> ReadByDoctorId(int doctorId);
        List<Appointment> ReadByDateAndNotDoctor(int doctorId, DateTime date);
        List<Appointment> ReadByPatientId(int patientId);
    }
}
