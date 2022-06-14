namespace Hospital.View.DoctorView.Validation
{
    public class AppointmentValidation : ValidationBase
    {
        private string _date;
        private string _time;
        private string _duration;
        private string _room;

        public string Date
        {
            get => _date;
            set
            {
                if (_date == value) return;
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public string Time
        {
            get => _time;
            set
            {
                if (_time == value) return;
                _time = value;
                OnPropertyChanged("Time");
            }
        }
        
        public string Duration
        {
            get => _duration;
            set
            {
                if (_duration == value) return;
                _duration = value;
                OnPropertyChanged("Duration");
            }
        }
        
        public string Room
        {
            get => _room;
            set
            {
                if (_room == value) return;
                _room = value;
                OnPropertyChanged("Room");
            }
        }

        protected override void ValidateSelf()
        {
            if(string.IsNullOrWhiteSpace(_date))
            {
                ValidationErrors["Date"] = "Select date.";
            }
            if (string.IsNullOrWhiteSpace(_time))
            {
                ValidationErrors["Time"] = "Select time.";
            }
            if (string.IsNullOrWhiteSpace(_duration))
            {
                ValidationErrors["Duration"] = "Select duration.";
            }
            if (string.IsNullOrWhiteSpace(_room))
            {
                ValidationErrors["Room"] = "Select room.";
            }
        }
    }
}