using Hospital.Model;
using Hospital.View.PatientView.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.View.PatientView
{
    /// <summary>
    /// Interaction logic for MedicalRecord.xaml
    /// </summary>
    public partial class MedicalRecord : Page
    {
        public Patient patient;
        MedicalRecordViewModel mrvm;

        public MedicalRecord(PatientWindow patientWindow, User user, Patient patient, Address address, City city, Country country, Model.MedicalRecord medicalRecord, ObservableCollection<Allergen> allergens)
        {
            mrvm = new MedicalRecordViewModel(PatientWindow.getInstance().frame.NavigationService, user, address, city, country, medicalRecord, allergens);
            InitializeComponent();
            this.DataContext = mrvm;
            
        }

    }
}
