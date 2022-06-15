using Hospital.Model;

namespace Hospital.Repository.PatientRepo
{
    public interface IPatientRepository : IRepositoryBase<Patient, int>
    { 
        Patient ReadByIdTest(int id);
        Patient ReadByUsername(string username);
    }
}