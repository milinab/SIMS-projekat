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


namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Page
    {

        private App app;
        private readonly object _content;
        private readonly PatientWindow _patientWindow;
        private readonly Notes _notes;

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
            Note newNote = new Note
            {
                Name = noteName.Text,
                NoteText = noteText.Text,
                Date = DateTime.Now
            };
            app._noteController.Create(newNote);
            _notes.BackToNotes();
            Page note = new Notes(_patientWindow);
            this.frame.Navigate(note);

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
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri(@"insertNoteName.png", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
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
                // Create an ImageBrush.
                ImageBrush textImageBrush = new ImageBrush();
                textImageBrush.ImageSource =
                    new BitmapImage(
                        new Uri(@"insertNoteText.png", UriKind.Relative)
                    );
                textImageBrush.AlignmentX = AlignmentX.Left;
                textImageBrush.AlignmentY = AlignmentY.Top;
                textImageBrush.Stretch = Stretch.None;
                // Use the brush to paint the button's background.
                noteText.Background = textImageBrush;
            }
            else
            {

                noteText.Background = null;
            }
        }
    }
}
