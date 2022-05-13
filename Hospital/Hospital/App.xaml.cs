using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using Hospital.View.DoctorView;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal AllergenController _allergenController;
        internal AddressController _addressController;
        internal AppointmentController _appointmentController;
        internal CityController _cityController;
        internal CountryController _countryController;
        internal DoctorController _doctorController;
        internal EmployeeController _employeeController;
        internal EquipmentController _equipmentController;
        internal GuestController _guestController;
        internal ManagerController _managerController;
        internal MedicalRecordController _medicalRecordController;
        internal PatientController _patientController;
        internal RoomController _roomController;
        internal SecretaryController _secretaryController;
        internal SurgeryController _surgeryController;
        internal UserController _userController;
        internal TherapyController _therapyController;
        internal MedicineController _medicineController;
        internal SurveyController _surveyController;
        internal DoctorSurveyResponseController _doctorSurveyResponseController;
        internal HospitalSurveyResponseController _hospitalSurveyResponseController;
        internal QuestionController _questionController;
        internal NoteController _noteController;
        internal TrolController _trolController;

        internal MainPage _mainPage;

        public App()
        {
            Repositories repositories = new Repositories();
            Services services = new Services(repositories);

            _allergenController = new AllergenController(services.AllergenService);
            _addressController = new AddressController(services.AddressService);
            _appointmentController = new AppointmentController(services.AppointmentService);
            _cityController = new CityController(services.CityService);
            _countryController = new CountryController(services.CountryService);
            _doctorController = new DoctorController(services.DoctorService);
            _employeeController = new EmployeeController(services.EmployeeService);
            _equipmentController = new EquipmentController(services.EquipmentService);
            _guestController = new GuestController(services.GuestService);
            _managerController = new ManagerController(services.ManagerService);
            _medicalRecordController = new MedicalRecordController(services.MedicalRecordService);
            _patientController = new PatientController(services.PatientService);
            _roomController = new RoomController(services.RoomService);
            _secretaryController = new SecretaryController(services.SecretaryService);
            _surgeryController = new SurgeryController(services.SurgeryService);
            _userController = new UserController(services.UserService);
            _therapyController = new TherapyController(services.TherapyService);
            _medicineController = new MedicineController(services.MedicineService);
            _surveyController = new SurveyController(services.SurveyService);
            _doctorSurveyResponseController = new DoctorSurveyResponseController(services.DoctorSurveyResponseService);
            _hospitalSurveyResponseController = new HospitalSurveyResponseController(services.HospitalSurveyResponseService);
            _questionController = new QuestionController(services.QuestionService);
            _noteController = new NoteController(services.NoteService);
            _trolController = new TrolController(services.TrolService);

            _mainPage = new MainPage();
        }
    }
}
