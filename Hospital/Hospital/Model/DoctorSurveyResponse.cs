using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class DoctorSurveyResponse : INotifyPropertyChanged
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Survey HS { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int DoctorId { get; set; }
        [DataMember]
        public int Grade { get; set; }

        public DoctorSurveyResponse()
        {
        }

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public System.Collections.ArrayList doctorSurveyResponses;

        public event PropertyChangedEventHandler PropertyChanged;

        public System.Collections.ArrayList GetDoctorSurveyResponse()
        {
            if (doctorSurveyResponses == null)
                doctorSurveyResponses = new System.Collections.ArrayList();
            return doctorSurveyResponses;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetDoctorSurveyResponse(System.Collections.ArrayList newDoctorSurveyResponse)
        {
            RemoveAllDoctorSurveyResponses();
            foreach (DoctorSurveyResponse oDoctorSurveyResponse in newDoctorSurveyResponse)
                AddDoctorSurveyResponse(oDoctorSurveyResponse);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddDoctorSurveyResponse(DoctorSurveyResponse newDoctorSurveyResponse)
        {
            if (newDoctorSurveyResponse == null)
                return;
            if (this.doctorSurveyResponses == null)
                this.doctorSurveyResponses = new System.Collections.ArrayList();
            if (!this.doctorSurveyResponses.Contains(newDoctorSurveyResponse))
                this.doctorSurveyResponses.Add(newDoctorSurveyResponse);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveDoctorSurveyResponse(DoctorSurveyResponse oldDoctorSurveyResponse)
        {
            if (oldDoctorSurveyResponse == null)
                return;
            if (this.doctorSurveyResponses != null)
                if (this.doctorSurveyResponses.Contains(oldDoctorSurveyResponse))
                    this.doctorSurveyResponses.Remove(oldDoctorSurveyResponse);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllDoctorSurveyResponses()
        {
            if (doctorSurveyResponses != null)
                doctorSurveyResponses.Clear();
        }
    }
}