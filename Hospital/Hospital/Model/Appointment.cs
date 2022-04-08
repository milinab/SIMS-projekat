using System;

namespace Hospital.Model
{
   public class Appointment
   {
      public int Id;
      public DateTime Date;
      public TimeSpan Duration;
      
      public Doctor doctor;
      public Patient patient;
      public Room room;
   
   }
}