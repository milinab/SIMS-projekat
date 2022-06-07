using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;
using Tulpep.NotificationWindow;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        public Patient patient;

        public ObservableCollection<Note> NotesList
        {
            get;
            set;
        }

        public Notes(PatientWindow patientWindow)
        {
            InitializeComponent();
            app = Application.Current as App;
            _content = Content;
            this.DataContext = this;
            _patientWindow = patientWindow;
            dataGridNotes.ItemsSource = app._noteController.Read();
            this.selectForDelete.Visibility = Visibility.Hidden;
        }

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
        private void Notes_Click(object sender, RoutedEventArgs e)
        {
            Content = _content;
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

        public void BackToPatientWindow()
        {
            Content = _content;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }

        private void InfoButtonClick(object sender, RoutedEventArgs e)
        {
            Note note = dataGridNotes.SelectedValue as Note;
            Page infoNote = new NoteInfo(_patientWindow, note);
            this.frame.NavigationService.RemoveBackEntry();
            this.frame.Content = null;
            this.frame.Navigate(infoNote);
   
        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            Page addNote = new AddNote(_patientWindow, this);
            this.frame.NavigationService.RemoveBackEntry();
            this.frame.Content = null;
            this.frame.Navigate(addNote);
            
            
        }

        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridNotes.SelectedItem != null)
            {
                this.selectForDelete.Visibility = Visibility.Hidden;
                Note note = (Note)dataGridNotes.SelectedItem;
                app._noteController.Delete(note.Id);
            }
            else
            {
                PopupNotification.sendPopupNotification("Warning", "Please, select the note You want to delete.");
                this.selectForDelete.Visibility = Visibility.Visible;
            }
        }



        public void BackToNotes()
        {
            Content = _content;
            Refresh();
        }
        public void Refresh()
        {
            dataGridNotes.ItemsSource = app._noteController.Read();
        }

       
    }
}
