using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace Hospital.Model
{
    [DataContract]
    public class Medicine
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _id;
        private string _name;
        private string _description;
        private int _number;

        [DataMember]
        public string Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        [DataMember]
        public string Description
        {
            get { return _description; }
            set {
                    if(value != _description)
                    {
                        _description = value;
                    OnPropertyChanged("Description");
                    }
                }
        }

        [DataMember]
        public int Number
        {
            get { return _number; }
            set
            {
                if (value != _number)
                {
                    _number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        [DataMember]
        public List<int> AllergenIds { get; set; }

        public Medicine()
        {

        }

        public Medicine(string id, string name, string description, int number)
        {
            Id = id;
            Name = name;
            Description = description;
            Number = number;
        }

        public Medicine(string name, string description, int number)
        {
            Name = name;
            Description = description;
            Number = number;
        }

    }
}
