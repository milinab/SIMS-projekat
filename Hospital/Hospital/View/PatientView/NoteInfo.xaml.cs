using Hospital.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for NoteInfo.xaml
    /// </summary>
    public partial class NoteInfo : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private int _id;
        private App app;
        private readonly PatientWindow _patientWindow;
        private DateTime _date;

        private string _noteName;
        private string _noteText;
        public Patient patient;

        public string NoteName
        {

            get { return _noteName; }
            set
            {
                if (value != _noteName)
                {
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
        public NoteInfo(PatientWindow patientWindow, Note note)
        {
            InitializeComponent();
            app = Application.Current as App;
            PatientWindow.getInstance().frame.Content = null;

            this.DataContext = this;
            _patientWindow = patientWindow;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);

            this.NoteText = note.NoteText;
            this.NoteName = note.Name;
            _date = note.Date;
            this.dateText.Text = note.Date.ToString("d.M.yyyy H:mm");
            this.notifyDate.Text = note.NotificationDate.ToString("d.M.yyyy H:mm");
            _id = note.Id;
        }

        private bool Validate()
        {
            if (TimePicker.Value == null)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a time");
                return false;
            }

            if (myCalendar.SelectedDate.HasValue == false)
            {
                PopupNotification.SendPopupNotification("Warning", "You need to select a date");
                return false;
            }
            return true;
        }
       
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if(Validate())
            {
                patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
                DateTime date = myCalendar.SelectedDate.Value;
                string time = TimePicker.Text;
                string[] timeParts = time.Split(':');
                date += new TimeSpan(int.Parse(timeParts[0]), int.Parse(timeParts[1]), 0);
                Note note = new Note(noteName.Text, _id, noteText.Text, DateTime.Now, date, patient.Id);

                if (this.noteName.Text != "" || this.noteText.Text != "")
                {
                    app._noteController.Edit(note);
                    PopupNotification.SendPopupNotification("Success!", "Your note is edited successfully!");
                }
            }
        }

        private void BackToAllNotes_Click(object sender, RoutedEventArgs e)
        {
            Page note = new Notes(_patientWindow);
            PatientWindow.getInstance().frame.Navigate(note);

        }

    }
}
