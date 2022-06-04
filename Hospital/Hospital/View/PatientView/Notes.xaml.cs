using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.Model;
using System.Collections.ObjectModel;
using Hospital.Controller;
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
        private Note note;
        private readonly PatientWindow _patientWindow;
        

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
            User user = app._userController.ReadById(1);
            Patient patient = app._patientController.ReadById(1);
            Address address = app._addressController.ReadById(1);
            City city = app._cityController.ReadById(1);
            Country country = app._countryController.ReadById(1);
            Model.MedicalRecord medicalRecord = app._medicalRecordController.ReadById(1);
            Allergen allergen = app._allergenController.ReadById(1);
            Page medicalRecordPage = new MedicalRecord(_patientWindow, user, patient, address, city, country, medicalRecord, allergen);
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
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.notification;
                popup.TitleText = "Warning";
                popup.ContentText = "Please, select the note You want to delete.";
                popup.Popup();
                //MessageBox.Show("Select a note You want to delete.", "Warning");
                this.selectForDelete.Visibility = Visibility.Visible;
            }
        }



        public void BackToNotes()
        {
            Content = _content;
            refresh();
        }
        public void refresh()
        {
            dataGridNotes.ItemsSource = app._noteController.Read();
        }

       
    }
}
