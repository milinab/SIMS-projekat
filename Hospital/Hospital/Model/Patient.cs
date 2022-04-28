using System;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Patient : User
    {
        private string _gender;
        private string _bloodType;
        private string _healthInsuranceID;
        [DataMember]
        public int MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        [DataMember]
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
        [DataMember]
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
        [DataMember]
        public string HealthInsuranceId
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
    }
}