using System;
using System.Collections.Generic;

namespace Hospital.Model
{
    public class PatientHandler
   {
      public Patient ReadById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public void Create(Patient newPatient)
      {
            PatientList.Add(newPatient);
        }
      
      public void Edit(int id)
      {
         // TODO: implement
      }
      
      public void Delete(int id)
      {
         // TODO: implement
      }
      
      public List<Patient> ReadAll()
      {
         // TODO: implement
         return null;
      }
   
      public PatientFileHandler patientFileHandler { get; set; }

        public List<Patient> PatientList = new List<Patient>();

    }
}