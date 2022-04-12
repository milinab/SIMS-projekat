using System;
using System.ComponentModel;

namespace Hospital.Model
{
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
   
        
   }

}