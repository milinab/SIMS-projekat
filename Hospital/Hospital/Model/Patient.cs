using System;

namespace Hospital.Model
{
   public class Patient : User
   {
      public GenderType Gender;
      public BloodType BloodType;
      public string HealthInsuranceID;
      
      public MedicalRecord medicalRecord;
   
   }
}