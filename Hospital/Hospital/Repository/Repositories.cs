using Hospital.Repository.AnamnesisRepo;
using Hospital.Repository.AppointmentRepo;
using Hospital.Repository.CityRepo;
using Hospital.Repository.CountryRepo;
using Hospital.Repository.DoctorRepo;
using Hospital.Repository.DoctorSurveyResponseRepo;
using Hospital.Repository.EmployeeRepo;
using Hospital.Repository.EquipmentRepo;
using Hospital.Repository.GuestRepo;
using Hospital.Repository.HospitalSurveyResponseRepo;
using Hospital.Repository.ManagerRepo;
using Hospital.Repository.MedicalRecordRepo;
using Hospital.Repository.MedicineReplaceRepo;
using Hospital.Repository.MedicineRepo;
using Hospital.Repository.NoteRepo;
using Hospital.Repository.PatientRepo;
using Hospital.Repository.QuestionRepo;
using Hospital.Repository.ReferralRepo;
using Hospital.Repository.RoomRepo;
using Hospital.Repository.SecretaryRepo;
using Hospital.Repository.SurgeryRepo;
using Hospital.Repository.SurveyRepo;
using Hospital.Repository.TherapyRepo;
using Hospital.Repository.TrollRepo;
using Hospital.Repository.UserRepo;
using Hospital.Repository.VacationRepo;

namespace Hospital.Repository
{
    public class Repositories
    {
        public AllergenRepos.AllergenRepository AllergenRepository { get; set; }
        public AddressRepo.AddressRepository AddressRepository { get; set; }
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
        public ReferralRepository ReferralRepository { get; set; }

        public Repositories()
        {
            AllergenRepository = new AllergenRepos.AllergenRepository();
            CountryRepository = new CountryRepository();
            CityRepository = new CityRepository(CountryRepository);
            AddressRepository = new AddressRepo.AddressRepository(CityRepository);
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
            ReferralRepository = new ReferralRepository();
        }
    }
}