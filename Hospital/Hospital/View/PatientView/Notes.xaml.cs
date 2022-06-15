using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

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
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
            dataGridNotes.ItemsSource = app._noteController.ReadByPatientId(patient.Id);
            this.selectForDelete.Visibility = Visibility.Hidden;
        }


        private void InfoButtonClick(object sender, RoutedEventArgs e)
        {
            Note note = dataGridNotes.SelectedValue as Note;
            Page infoNote = new NoteInfo(_patientWindow, note);
            //this.frame.NavigationService.RemoveBackEntry();
            PatientWindow.getInstance().frame.Content = null;
            PatientWindow.getInstance().frame.Navigate(infoNote);

        }

        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            Page addNote = new AddNote(_patientWindow, this);
            //this.frame.NavigationService.RemoveBackEntry();
            PatientWindow.getInstance().frame.Content = null;
            PatientWindow.getInstance().frame.Navigate(addNote);


        }

        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridNotes.SelectedItem != null)
            {
                this.selectForDelete.Visibility = Visibility.Hidden;
                Note note = (Note)dataGridNotes.SelectedItem;
                app._noteController.Delete(note.Id);
                Refresh();
            }
            else
            {
                PopupNotification.SendPopupNotification("Warning", "Please, select the note You want to delete.");
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
