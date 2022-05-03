using Hospital.Repository;

namespace Hospital.Service
{
    public class Services
    {
        public AllergenService AllergenService { get; set; }
        public AddressService AddressService { get; set; }
        public AppointmentService AppointmentService { get; set; }
        public CityService CityService { get; set; }
        public CountryService CountryService { get; set; }
        public DoctorService DoctorService { get; set; }
        public EmployeeService EmployeeService { get; set; }
        public EquipmentService EquipmentService { get; set; }
        public GuestService GuestService { get; set; }
        public ManagerService ManagerService { get; set; }
        public MedicalRecordService MedicalRecordService { get; set; }
        public PatientService PatientService { get; set; }
        public RoomService RoomService { get; set; }
        public SecretaryService SecretaryService { get; set; }
        public SurgeryService SurgeryService { get; set; }
        public UserService UserService { get; set; }


        public Services(Repositories repositories)
        {
            AllergenService = new AllergenService(repositories.AllergenRepository);
            AddressService = new AddressService(repositories.AddressRepository);
            AppointmentService = new AppointmentService(repositories.AppointmentRepository);
            CityService = new CityService(repositories.CityRepository);
            CountryService = new CountryService(repositories.CountryRepository);
            DoctorService = new DoctorService(repositories.DoctorRepository);
            EmployeeService = new EmployeeService(repositories.EmployeeRepository);
            EquipmentService = new EquipmentService(repositories.EquipmentRepository);
            GuestService = new GuestService(repositories.GuestRepository);
            ManagerService = new ManagerService(repositories.ManagerRepository);
            MedicalRecordService = new MedicalRecordService(repositories.MedicalRecordRepository);
            PatientService = new PatientService(repositories.PatientRepository);
            RoomService = new RoomService(repositories.RoomRepository);
            SecretaryService = new SecretaryService(repositories.SecretaryRepository);
            SurgeryService = new SurgeryService(repositories.SurgeryRepository);
            UserService = new UserService(repositories.UserRepository);
        }
    }
}