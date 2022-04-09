using System;

namespace Hospital.Model
{

    public enum GenderType {
        Musko,
        Zensko
    }

    public enum BloodType {
        OPositive,
        ONegative,
        APositive,
        ANegative,
        BPositive,
        BNegative,
        ABPositive,
        ABNegative,
    }

   public class Patient : User
   {
      public GenderType Gender;
      public BloodType BloodType;
      public string HealthInsuranceID;
      
      public MedicalRecord medicalRecord;
   
   }
}