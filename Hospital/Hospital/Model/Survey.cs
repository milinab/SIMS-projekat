using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Hospital.Enums;

namespace Hospital.Model
{
    [DataContract]
    public class Survey: INotifyPropertyChanged 
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Question> Questions { get; set; }
        [DataMember]
        public DateTime ExpirationDate { get; set; }

        //public SurveyType Type { get; set; }
            
        public Survey()
        {
        }

        private void OnPropertyChanged(string name) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public System.Collections.ArrayList surveys;

        public event PropertyChangedEventHandler PropertyChanged;

        public System.Collections.ArrayList GetSurveys() {
            if (surveys == null)
                surveys = new System.Collections.ArrayList();
            return surveys;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetSurvey(System.Collections.ArrayList newSurvey) {
            RemoveAllSurveys();
            foreach (Survey oSurvey in newSurvey)
                AddSurvey(oSurvey);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddSurvey(Survey newSurvey) {
            if (newSurvey == null)
                return;
            if (this.surveys == null)
                this.surveys = new System.Collections.ArrayList();
            if (!this.surveys.Contains(newSurvey))
                this.surveys.Add(newSurvey);
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveSurvey(Survey oldSurvey) {
            if (oldSurvey == null)
                return;
            if (this.surveys != null)
                if (this.surveys.Contains(oldSurvey))
                    this.surveys.Remove(oldSurvey);
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllSurveys() {
            if (surveys != null)
                surveys.Clear();
        }
    }
}