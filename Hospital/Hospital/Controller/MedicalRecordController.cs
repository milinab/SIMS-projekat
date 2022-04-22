using System;
using System.Collections.Generic;

namespace Hospital.Model
{
   public class MedicalRecordController
   {
      public MedicalRecord ReadById(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public void Create(MedicalRecord newMedicalRecord)
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
      
      public List<MedicalRecord> ReadAll()
      {
         // TODO: implement
         return null;
      }
   
      public MedicalRecordRepository medicalRecordFileHandler;
   
      private List<MedicalRecord> MedicalRecords;
   
   }
}