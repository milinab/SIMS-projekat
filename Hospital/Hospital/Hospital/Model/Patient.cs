using System;

namespace Hospital.Model
{

    


   public class Patient : User
   {

       public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        public string BloodType
        {
            get
            {
                return _bloodType;
            }
            set
            {
                if (value != _bloodType)
                {
                    _bloodType = value;
                    OnPropertyChanged("BloodType");
                }
            }
        }

        public String HealthInsuranceId
        {
            get
            {
                return _healthInsuranceID;
            }
            set
            {
                if (value != _healthInsuranceID)
                {
                    _healthInsuranceID = value;
                    OnPropertyChanged("HealthInsuranceId");
                }
            }
        }

       

        private string _gender;
        private string _bloodType;
        private string _healthInsuranceID;
      
        public MedicalRecord medicalRecord;
   
   }
}