using Hospital.Model;
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

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for NoteInfo.xaml
    /// </summary>
    public partial class NoteInfo : Page
    {
        private int _id;
        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        private DateTime _date;
        public NoteInfo(PatientWindow patientWindow, Note note)
        {
            InitializeComponent();
            app = Application.Current as App;
            this.frame.Content = null;
            this.frame.NavigationService.RemoveBackEntry();

            this.DataContext = this;
            _patientWindow = patientWindow;
            
            this.noteText.Text = note.NoteText;
            this.noteName.Text = note.Name;
            _date = note.Date;
            this.dateText.Text = note.Date.ToString("d.M.yyyy H:mm");
            _id = note.Id;
        }
        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            _patientWindow.BackToPatientWindow();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            _patientWindow.Close();

        }
        private void Surveys_Click(object sender, RoutedEventArgs e)
        {
            Content = _content;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Note note = new Note(noteName.Text,_id, noteText.Text, DateTime.Now);
            app._noteController.Edit(note);

        }

        private void BackToAllNotes_Click(object sender, RoutedEventArgs e)
        {
            Page note = new Notes(_patientWindow);
            this.frame.Navigate(note);

        }
    }
}
