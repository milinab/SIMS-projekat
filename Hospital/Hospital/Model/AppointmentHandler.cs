using System;

namespace Hospital.Model
{
   public class AppointmentHandler
   {
      public Appointment ReadById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public void Create(Appointment newAppointment)
      {
         // TODO: implement
      }
      
      public void Edit(int id)
      {
         // TODO: implement
      }
      
      public void Delete(int id)
      {
         // TODO: implement
      }
      
      public List<Appointment> ReadAll()
      {
         // TODO: implement
         return null;
      }
   
      public AppointmentFileHandler appointmentFileHandler;
   
      private List<Appointment> Appointments;
   
   }
}