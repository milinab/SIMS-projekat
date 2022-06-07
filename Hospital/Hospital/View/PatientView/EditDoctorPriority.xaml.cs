using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using Tulpep.NotificationWindow;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for EditDoctorPriority.xaml
    /// </summary>
    public partial class EditDoctorPriority : Page
    {
        private App app;
        //private readonly EditAnAppointment _editAnAppointment;
        private readonly PatientWindow _patientWindow;
        //private readonly AppointmentController _appointmentController;
        private int _doctorId;
        private DateTime _date;
        private String chosenDoctor;
        private Doctor doctor;
        private int _id;
        private Doctor selectedDoctor;
        public Patient patient;

        private String DoctorName
        {
            set { chosenDoctor = value; }
            get { return chosenDoctor; }
        }

        ObservableCollection<Appointment> DoctorsAppointments { get; set; }

        ObservableCollection<Appointment> AvailableAppointments { get; set; }



        /*public EditDoctorPriority(PatientWindow patientWindow, EditAnAppointment editAnAppointment, AppointmentController appointmentController)
        {
            InitializeComponent();
            _editAnAppointment = editAnAppointment;
            _patientWindow = patientWindow;
            _appointmentController = appointmentController;
        }*/

        public EditDoctorPriority(int doctorId, DateTime date, EditAnAppointment editAnAppointment, PatientWindow patientWindow, int appointmantId)
        {
            InitializeComponent();
            app = Application.Current as App;
            //this.frame.Content = null;
            //this.frame.NavigationService.RemoveBackEntry();
            //_editAnAppointment = editAnAppointment;
            _id = appointmantId;
            _patientWindow = patientWindow;
            _doctorId = doctorId;
            _date = date;
            DoctorsAppointments = new ObservableCollection<Appointment>();
            AvailableAppointments = new ObservableCollection<Appointment>();
            InitializeData(doctorId, date);
            dataGridDoctorPriority.ItemsSource = AvailableAppointments;
            dataGridAppointments.ItemsSource = patientWindow.Appointments;
            selectedDoctor = this.doctor;
        }
        private void InitializeData(int doctorId, DateTime date)
        {
            Doctor doctor = app._doctorController.ReadById(doctorId);
            this.doctor = doctor;
            DoctorName = doctor.Name;
            this.ChosenDoctor.Text = doctor.Name + " " + doctor.LastName;

            // radno vreme bolnice
            List<TimeSpan> hospitalWorkingHours = new List<TimeSpan>
            {
                new TimeSpan(7, 00, 00),
                new TimeSpan(7, 30, 00),
                new TimeSpan(8, 00, 00),
                new TimeSpan(8, 30, 00),
                new TimeSpan(9, 00, 00),
                new TimeSpan(9, 30, 00),
                new TimeSpan(10, 00, 00),
                new TimeSpan(10, 30, 00)
            };

            List<TimeSpan> hospitalWorkingHoursListForCalculation = new List<TimeSpan>(hospitalWorkingHours);

            // pronadji sve appointmente tog lekara, uzmi njigovo pocetno vreme i izbrisi iz liste allAppointmentTImes ako se poklapaju

            DoctorsAppointments = new ObservableCollection<Appointment>();
            DoctorsAppointments = app._appointmentController.ReadByDoctorId(doctorId);

            AvailableAppointments = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorName, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);
            //findAvailabeAppointments(DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, date);

            if (AvailableAppointments.Count == 0)
            {
                DateTime tommorow = date.AddDays(1); //uzmes sutradan
                _date = tommorow;
                PopupNotification.sendPopupNotification("Warning", "Sorry to inform, but there is no available appointments for chosen date. In the following list, we are gonna show You available appointments for the next available day.");
                //findAvailabeAppointments(DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, tommorow);
                AvailableAppointments = app._appointmentController.FindAvailableAppointments(selectedDoctor, _date, DoctorName, DoctorsAppointments, hospitalWorkingHours, hospitalWorkingHoursListForCalculation, tommorow);

            }
        }
            
        private void ConfirmAppointment_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = dataGridDoctorPriority.SelectedItem as Appointment;

            Patient patient = new Patient();
            patient.Id = _patientWindow.patient.Id;
            TimeSpan duration = new TimeSpan(0, 0, 30, 0);
            Room room = new Room();
            room.Id = 2;
            var selectedDate = SelectedItem.Date;

            Appointment ap = new Appointment(_id, selectedDate, duration, doctor, patient, room);
            app._appointmentController.Edit(ap);

            TrollSystem.troll(_patientWindow, app);

            /*Trol troll = app._trolController.ReadByPatientId(_patientWindow.patient.Id);
            if (troll == null)
            {
                Trol tr = new Trol(_patientWindow.patient.Id, DateTime.Now, 1);
                app._trolController.Create(tr);
            }
            else
            {
                if ((DateTime.Now - troll.StartDate).TotalDays < 30)
                {
                    //ovo je okej, dozvoli
                    troll.NumberOfCancellations += 1;
                    app._trolController.Edit(troll);
                    Trol newTroll = app._trolController.ReadById(troll.Id);
                    if (newTroll.NumberOfCancellations >= 5)
                    {
                        _patientWindow.patient.IsActive = false;

                        app._patientController.Edit(_patientWindow.patient);
                        app._trolController.Delete(troll.Id);
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.notification;
                        popup.TitleText = "Warning";
                        popup.ContentText = "Your account is banned due to..";
                        popup.Popup();
                        //MessageBox.Show("Your account is banned due to..");
                        LogIn logIn = new LogIn();
                        logIn.Show();
                        _patientWindow.Close();
                    }
                }
                else
                {
                    app._trolController.Delete(troll.Id);
                    Trol tr = new Trol(_patientWindow.patient.Id, DateTime.Now, 1);
                    app._trolController.Create(tr);
                }
            }*/
            _patientWindow.BackToPatientWindow();

/*            Appointment appointment = new Appointment(a, new TimeSpan(0, 30, 00), doctor, patient, room);
            app._appointmentController.Create(appointment);
            _patientWindow.BackToPatientWindow();*/
        }

        /*public void findAvailabeAppointments(ObservableCollection<Appointment> DoctorsAppointments,
            List<TimeSpan> hospitalWorkingHours, List<TimeSpan> hospitalWorkingHoursListForCalculation, DateTime date)
        {

            List<TimeSpan> cloneList = new List<TimeSpan>(hospitalWorkingHoursListForCalculation);
            foreach (Appointment a in DoctorsAppointments)
            {

                var appStartTime = a.Date;
                var appEndTime = a.Date + a.Duration;

                foreach (TimeSpan appTime in hospitalWorkingHours)
                {
                    //DateTime dt = new DateTime(date);
                    date = date + appTime;
                    if (DateTime.Compare(date, appStartTime) > 0)
                    {
                        if (DateTime.Compare(date, appEndTime) < 0)
                        {
                            if (cloneList.Contains(appTime))
                            {
                                cloneList.Remove(appTime);
                            }

                        }
                        else if (DateTime.Compare(date, appEndTime) == 0)
                        {
                            cloneList.Remove(appTime);
                        }
                    }
                    else if (DateTime.Compare(date, appStartTime) == 0)
                    {
                        if (DateTime.Compare(date, appEndTime) < 0)
                        {
                            if (cloneList.Contains(appTime))
                            {
                                cloneList.Remove(appTime);
                            }
                        }
                    }
                    date = _date;
                }
            }

            foreach (TimeSpan time in cloneList)
            {
                Appointment app = new Appointment();
                app.Date = _date + time;

                AvailableAppointments.Add(app);
            }

        }*/

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            Page homePage = new HomePage(_patientWindow);
            this.frame.Navigate(homePage);
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            Page profilePage = new Profile(_patientWindow);
            this.frame.Navigate(profilePage);
        }

        private void MedicalRecord_Click(object sender, RoutedEventArgs e)
        {
            User user = app._userController.ReadById(patient.Id);
            Address address = app._addressController.ReadById(user.Address.Id);
            City city = app._cityController.ReadById(user.Address.CityId);
            Country country = app._countryController.ReadById(1); //country nije postavljen u address modelu
            Model.MedicalRecord medicalRecord = app._medicalRecordController.ReadById(patient.MedicalRecordId);
            ObservableCollection<Allergen> allergens = app._allergenController.ReadByIds(medicalRecord.AllergenIds);

            Page medicalRecordPage = new MedicalRecord(_patientWindow, user, patient, address, city, country, medicalRecord, allergens);
            this.frame.Navigate(medicalRecordPage);
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }
        private void MyTherapy_Click(object sender, RoutedEventArgs e)
        {
            Page myTherapyPage = new MyTherapy(_patientWindow);
            this.frame.Navigate(myTherapyPage);
        }

        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            Page calendarPage = new Calendar(_patientWindow);
            this.frame.Navigate(calendarPage);
        }
        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            Page notesPage = new Notes(_patientWindow);
            this.frame.Navigate(notesPage);
        }

        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            Page hospitalSurveyPage = new Surveys(_patientWindow);
            this.frame.Navigate(hospitalSurveyPage);
        }
        private void Notification_Click(object sender, RoutedEventArgs e)
        {
            Page notificationPage = new Notification(_patientWindow);
            this.frame.Navigate(notificationPage);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            _patientWindow.BackToPatientWindow();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }
    }
}
