using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class HospitalSurveyResponse : INotifyPropertyChanged
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Survey HS { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

        public HospitalSurveyResponse()
        {
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public System.Collections.ArrayList hospitalSurveyResponses;

        public event PropertyChangedEventHandler PropertyChanged;

        public System.Collections.ArrayList GetHospitalSurveyResponse()
        {
            if (hospitalSurveyResponses == null)
                hospitalSurveyResponses = new System.Collections.ArrayList();
            return hospitalSurveyResponses;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetHospitalSurveyResponse(System.Collections.ArrayList newHospitalSurveyResponse)
        {
            RemoveAllHospitalSurveyResponses();
            foreach (HospitalSurveyResponse oHospitalSurveyResponse in newHospitalSurveyResponse)
                AddHospitalSurveyResponse(oHospitalSurveyResponse);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddHospitalSurveyResponse(HospitalSurveyResponse newHospitalSurveyResponse)
        {
            if (newHospitalSurveyResponse == null)
                return;
            if (this.hospitalSurveyResponses == null)
                this.hospitalSurveyResponses = new System.Collections.ArrayList();
            if (!this.hospitalSurveyResponses.Contains(newHospitalSurveyResponse))
                this.hospitalSurveyResponses.Add(newHospitalSurveyResponse);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveHospitalSurveyResponse(HospitalSurveyResponse oldHospitalSurveyResponse)
        {
            if (oldHospitalSurveyResponse == null)
                return;
            if (this.hospitalSurveyResponses != null)
                if (this.hospitalSurveyResponses.Contains(oldHospitalSurveyResponse))
                    this.hospitalSurveyResponses.Remove(oldHospitalSurveyResponse);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllHospitalSurveyResponses()
        {
            if (hospitalSurveyResponses != null)
                hospitalSurveyResponses.Clear();
        }
    }
}