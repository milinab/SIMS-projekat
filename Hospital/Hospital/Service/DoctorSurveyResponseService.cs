using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.DoctorSurveyResponseRepo;

namespace Hospital.Service
{
    public class DoctorSurveyResponseService
    {
        private int _id;
        private readonly IDoctorSurveyResponseRepository _repository;

        public DoctorSurveyResponseService(IDoctorSurveyResponseRepository doctorSurveyResponseRepository)
        {
            _repository = doctorSurveyResponseRepository;
            List<DoctorSurveyResponse> doctorSurveyResponses = Read();
            if (doctorSurveyResponses.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = doctorSurveyResponses.Last().Id;
            }
        }

        public DoctorSurveyResponse ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(DoctorSurveyResponse newDoctorSurveyResponse)
        {
            newDoctorSurveyResponse.Id = GenerateId();
            _repository.Create(newDoctorSurveyResponse);
        }

        public void Edit(DoctorSurveyResponse editDoctorSurveyResponse)
        {
            _repository.Edit(editDoctorSurveyResponse);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<DoctorSurveyResponse> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
