using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using AutoMapper;
using Hospital.Model;

namespace Hospital.View.DoctorView.ViewModel
{
    public class AppointmentsPageViewModel : ViewModelBase
    {
        private ObservableCollection<AppointmentViewModel> _appointments;
        public IEnumerable<AppointmentViewModel> Appointments => _appointments;
        
        private string _currentTime;
        public string CurrentTime
        {
            get => _currentTime;
            set
            {
                if (_currentTime == value) return;
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            } 
        }
        
        public AppointmentsPageViewModel()
        {
            var app = Application.Current as App;
            DispatcherTimerSetup();
            SetAppointments(app);
        }

        /// <summary>
        /// Maps Appointments from Model to ViewModel and adds them to <see cref="_appointments"/> field
        /// </summary>
        /// <param name="app">Application object for the current AppDomain</param>
        private void SetAppointments(App app)
        {
            if (app?._appointmentController == null) return;
            
            _appointments = new ObservableCollection<AppointmentViewModel>();
            foreach (var appointment in app._appointmentController.Read())
            {
                var config = new MapperConfiguration(
                    cfg => cfg.CreateMap<Appointment, AppointmentViewModel>().ConstructUsing(
                        x => new AppointmentViewModel(appointment)));
                _appointments.Add(new Mapper(config).Map<AppointmentViewModel>(appointment));
            }
        }
    
        /// <summary>
        /// Calls CurrentTimeText method every second
        /// </summary>
        private void DispatcherTimerSetup()
        {
            DispatcherTimer liveDateTime = new DispatcherTimer 
            {                                                  
                Interval = TimeSpan.FromSeconds(1)             
            };                                                 
            liveDateTime.Tick += CurrentTimeText;                    
            liveDateTime.Start();                              
        }

        /// <summary>
        /// Sets current time to CurrentTime property in "ddd, d.M.yyyy.\nH:mm" string format
        /// </summary>
        private void CurrentTimeText(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToString("ddd, d.M.yyyy.\nH:mm");
        }
    }
}