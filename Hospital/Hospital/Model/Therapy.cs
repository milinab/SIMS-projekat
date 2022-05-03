using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Hospital.Model
{
    [DataContract]
    public class Therapy
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Medicine { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public string TherapyText { get; set; }
        
        public Therapy()
        {
        }

        public Therapy(int id, string medicine, DateTime time, string therapyText)
        {
            Id = id;
            Medicine = medicine;
            Time = time;
            TherapyText = therapyText;
        }

        private void OnPropertyChanged(string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public System.Collections.ArrayList therapies;

        public event PropertyChangedEventHandler PropertyChanged;

        public System.Collections.ArrayList GetTherapies()
        {
            if (therapies == null)
                therapies = new System.Collections.ArrayList();
            return therapies;
        }

        public void SetTherapy(System.Collections.ArrayList newTherapy)
        {
            RemoveAllTherapies();
            foreach (Therapy oTherapy in newTherapy)
                AddTherapy(oTherapy);
        }

        public void AddTherapy(Therapy newTherapy)
        {
            if (newTherapy == null)
                return;
            if (this.therapies == null)
                this.therapies = new System.Collections.ArrayList();
            if (!this.therapies.Contains(newTherapy))
                this.therapies.Add(newTherapy);
        }

        public void RemoveTherapy(Therapy oldTherapy)
        {
            if (oldTherapy == null)
                return;
            if (this.therapies != null)
                if (this.therapies.Contains(oldTherapy))
                    this.therapies.Remove(oldTherapy);
        }

        public void RemoveAllTherapies()
        {
            if (therapies != null)
                therapies.Clear();
        }
    }
}