using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Hospital.View.PatientView.ViewModel;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for PastAppointments.xaml
    /// </summary>
    public partial class PastAppointments : Page
    {
        private App app;
        private readonly object _content;
        PastAppointmentsViewModel pavm;
        public PastAppointments()
        { 
            InitializeComponent();
            app = Application.Current as App;
            pavm = new PastAppointmentsViewModel();
            this.DataContext = pavm;
            
        }
    }
}
