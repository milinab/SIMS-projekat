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
      
      public List<Patient> ReadAll()
      {
         // TODO: implement
         return null;
      }
   
      public PatientFileHandler patientFileHandler;
   
      private List<Patient> PatientAccounts;
   
   }
}