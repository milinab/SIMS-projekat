using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.View.PatientView.ViewModel
{
    internal class PastAppontmentsViewModel : ViewModelPatient
    {

        private ObservableCollection<Appointment> pastAppointments;
        private Model.Patient patient;



    }
}
