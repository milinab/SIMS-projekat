using Hospital.Model;
using Hospital.View.DoctorView.ViewModel;

namespace Hospital.View.DoctorView.Appointments {
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Add
    {
        public Add(Patient patient)
        {
            DataContext = new AddAppointmentViewModel(patient);
            InitializeComponent();
        }
    }
}