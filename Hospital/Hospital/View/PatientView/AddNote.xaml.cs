using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;

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
        private readonly PatientWindow _patientWindow;
        private readonly Notes _notes;

        private string _noteName;
        private string _noteText;
        public Patient patient;

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
            PatientWindow.getInstance().frame.Content = null;
            PatientWindow.getInstance().frame.NavigationService.RemoveBackEntry();

            this.DataContext = this;
            _patientWindow = patientWindow;
            _notes = notes;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            DateTime date = myCalendar.SelectedDate.Value;
            string time = TimePicker.Text;
            string[] timeParts = time.Split(':');
            date += new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);

            Note newNote = new Note(noteName.Text, noteText.Text, DateTime.Now, date, patient.Id);

            if (this.noteName.Text != "" && this.noteText.Text != "")
            {
                app._noteController.Create(newNote);
                _notes.BackToNotes();
                Page note = new Notes(_patientWindow);
                PatientWindow.getInstance().frame.Navigate(note);
            }
            else {
                Page note = new Notes(_patientWindow);
                PatientWindow.getInstance().frame.Navigate(note);
            }
            
        }

        private void BackToAllNotes_Click(object sender, RoutedEventArgs e)
        {
            Page note = new Notes(_patientWindow);
            PatientWindow.getInstance().frame.Navigate(note);

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
