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

        public Patient()
        {
        }

        public Patient(User user, MedicalRecord medicalRecord) : base(user)
        {
            this.MedicalRecord = medicalRecord;
        }
        public Patient(User user, string gender, string bloodType,
           string healthInsuranceId) : base(user)
        {
            _gender = gender;
            _bloodType = bloodType;
            _healthInsuranceID = healthInsuranceId;

        }

        public Patient(User user, string gender, string bloodType,
            string healthInsuranceId, MedicalRecord medicalRecord) : base(user)
        {
            _gender = gender;
            _bloodType = bloodType;
            _healthInsuranceID = healthInsuranceId;
            MedicalRecordId = medicalRecord.Id;
            MedicalRecord = medicalRecord;

        }

        public Patient(User user, string gender, string bloodType,
            string healthInsuranceId, MedicalRecord medicalRecord, int id) : base(user)
        {
            Id = id;
            _gender = gender;
            _bloodType = bloodType;
            _healthInsuranceID = healthInsuranceId;
            MedicalRecord = medicalRecord;
            MedicalRecordId = medicalRecord.Id;
        }
    }
}