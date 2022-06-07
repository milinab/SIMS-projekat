namespace Hospital.Repository
{
    public class Repositories
    {
        public AllergenRepository AllergenRepository { get; set; }
        public AddressRepository AddressRepository { get; set; }
        public AppointmentRepository AppointmentRepository { get; set; }
        public CityRepository CityRepository { get; set; }
        public CountryRepository CountryRepository { get; set; }
        public DoctorRepository DoctorRepository { get; set; }
        public EmployeeRepository EmployeeRepository { get; set; }
        public EquipmentRepository EquipmentRepository { get; set; }
        public GuestRepository GuestRepository { get; set; }
        public ManagerRepository ManagerRepository { get; set; }
        public MedicalRecordRepository MedicalRecordRepository { get; set; }
        public PatientRepository PatientRepository { get; set; }
        public RoomRepository RoomRepository { get; set; }
        public SecretaryRepository SecretaryRepository { get; set; }
        public SurgeryRepository SurgeryRepository { get; set; }
        public UserRepository UserRepository { get; set; }
        public TherapyRepository TherapyRepository { get; set; }
        public MedicineRepository MedicineRepository { get; set; }
        public SurveyRepository SurveyRepository { get; set; }
        public DoctorSurveyResponseRepository DoctorSurveyResponseRepository { get; set; }
        public HospitalSurveyResponseRepository HospitalSurveyResponseRepository { get; set; }
        public QuestionRepository QuestionRepository { get; set; }
        public NoteRepository NoteRepository { get; set; }
        public TrolRepository TrolRepository { get; set; }
        public MedicineReplaceRepository MedicineReplaceRepository { get; set; }
        public VacationRepository VacationRepository { get; set; }
        public AnamnesisRepository AnamnesisRepository { get; set; }

        public Repositories()
        {
            AllergenRepository = new AllergenRepository();
            CountryRepository = new CountryRepository();
            CityRepository = new CityRepository(CountryRepository);
            AddressRepository = new AddressRepository(CityRepository);
            MedicalRecordRepository = new MedicalRecordRepository();
            PatientRepository = new PatientRepository(AddressRepository, MedicalRecordRepository);
            DoctorRepository = new DoctorRepository();
            RoomRepository = new RoomRepository();
            AppointmentRepository = new AppointmentRepository(DoctorRepository, PatientRepository, RoomRepository);
            EmployeeRepository = new EmployeeRepository();
            EquipmentRepository = new EquipmentRepository();
            GuestRepository = new GuestRepository();
            ManagerRepository = new ManagerRepository();
            SecretaryRepository = new SecretaryRepository();
            SurgeryRepository = new SurgeryRepository();
            UserRepository = new UserRepository(AddressRepository);
            TherapyRepository = new TherapyRepository();
            MedicineRepository = new MedicineRepository();
            SurveyRepository = new SurveyRepository();
            DoctorSurveyResponseRepository = new DoctorSurveyResponseRepository();
            HospitalSurveyResponseRepository = new HospitalSurveyResponseRepository();
            QuestionRepository = new QuestionRepository();
            NoteRepository = new NoteRepository();
            TrolRepository = new TrolRepository();
            MedicineReplaceRepository = new MedicineReplaceRepository();
            VacationRepository = new VacationRepository(DoctorRepository);
            AnamnesisRepository = new AnamnesisRepository(TherapyRepository, AppointmentRepository);
        }
    }
}