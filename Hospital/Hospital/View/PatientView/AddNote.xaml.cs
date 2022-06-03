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
using System.ComponentModel;
using Hospital.View.PatientView.Validations;
namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        private readonly Notes _notes;

        private string _noteName;
        private string _noteText;

        public string NoteName {

            get { return _noteName; }
            set {
                if (value != _noteName) { 
                    _noteName = value;
                    OnPropertyChanged("NoteName");
                }
            }
        }

        public string NoteText
        {

            get { return _noteText; }
            set
            {
                if (value != _noteText)
                {
                    _noteText = value;
                    OnPropertyChanged("NoteText");
                }
            }
        }

        public AddNote(PatientWindow patientWindow, Notes notes)
        {
            InitializeComponent();
            app = Application.Current as App;
            this.frame.Content = null;
            this.frame.NavigationService.RemoveBackEntry();

            this.DataContext = this;
            _patientWindow = patientWindow;
            _notes = notes;
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
            Page medicalRecordPage = new MedicalRecord(_patientWindow);
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

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();
        }
       



        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            DateTime date = myCalendar.SelectedDate.Value;
            string time = TimePicker.Text;
            string[] timeParts = time.Split(':');
            date += new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);



            Note newNote = new Note(noteName.Text, noteText.Text, DateTime.Now, date);
/*
            Note newNote = new Note
            {
                Name = noteName.Text,
                NoteText = noteText.Text,
                Date = DateTime.Now,
                NotificationDate = date
            };
*/
            if (this.noteName.Text != "" && this.noteText.Text != "")
            {
                app._noteController.Create(newNote);
                _notes.BackToNotes();
                Page note = new Notes(_patientWindow);
                this.frame.Navigate(note);
            }
            else {
                Page note = new Notes(_patientWindow);
                this.frame.Navigate(note);
            }
            
        }

        private void BackToAllNotes_Click(object sender, RoutedEventArgs e)
        {
            Page note = new Notes(_patientWindow);
            this.frame.Navigate(note);

        }

        

        void NameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

            if (noteName.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"insertNoteName.png", UriKind.Relative)),
                    AlignmentX = AlignmentX.Left,
                    Stretch = Stretch.None
                };
                noteName.Background = textImageBrush;
            }
            else
            {
                noteName.Background = null;
            }
        }

        void TextTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

            if (noteText.Text == "")
            {
                ImageBrush textImageBrush = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri(@"insertNoteText.png", UriKind.Relative)),
                    AlignmentX = AlignmentX.Left,
                    AlignmentY = AlignmentY.Top,
                    Stretch = Stretch.None
                };
                noteText.Background = textImageBrush;
            }
            else
            {
                noteText.Background = null;
            }
        }
    }
}
