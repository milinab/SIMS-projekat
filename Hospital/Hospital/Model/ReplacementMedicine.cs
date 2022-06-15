using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    [DataContract]
    public class ReplacementMedicine
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private int _id;
        private string _name;
        private string _type;
        private int _number;
        private string _ingredients; 

        [DataMember]
        public int Id
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
        public string Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        [DataMember]
        public string Ingredients
        {
            get { return _ingredients; }
            set
            {
                if (value != _ingredients)
                {
                    _ingredients = value;
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

        public ReplacementMedicine()
        {

        }
        public ReplacementMedicine(int id, string name, string type, int number, string ingredients)
        {
            Id = id;
            Name = name;
            Type = type;
            Number = number;
            Ingredients = ingredients;
        }

        public ReplacementMedicine(string name, string type, int number, string ingredients)
        {
            Name = name;
            Type = type;
            Number = number;
            Ingredients = ingredients;
        }

    }
}
