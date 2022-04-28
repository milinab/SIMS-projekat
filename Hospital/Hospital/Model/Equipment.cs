using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Hospital.Model
{ 
    [DataContract]
    public class Equipment 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _id;
        private int _number;
        private string _name;

        [DataMember]
        public string Id
        {
            get { return _id; }
            set {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        [DataMember]
        public int Number
        {
            get { return _number; }
            set {
                if (value != _number)
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public Equipment(string id, int num, string name)
        {
            Id = id;
            Number = num;
            Name = name;
        }
    }
}