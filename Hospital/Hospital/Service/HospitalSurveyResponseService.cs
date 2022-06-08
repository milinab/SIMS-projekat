using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class HospitalSurveyResponseService
    {
        private int _id;
        private readonly HospitalSurveyResponseRepository _repository;

        public HospitalSurveyResponseService(HospitalSurveyResponseRepository hospitalSurveyResponseRepository)
        {
            _repository = hospitalSurveyResponseRepository;
            List<HospitalSurveyResponse> hospitalSurveyResponses = Read();
            if (hospitalSurveyResponses.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = hospitalSurveyResponses.Last().Id;
            }
        }

        public HospitalSurveyResponse ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(HospitalSurveyResponse newHospitalSurveyResponse)
        {
            newHospitalSurveyResponse.Id = GenerateId();
            _repository.Create(newHospitalSurveyResponse);
        }

        public void Edit(HospitalSurveyResponse editHospitalSurveyResponse)
        {
            _repository.Edit(editHospitalSurveyResponse);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<HospitalSurveyResponse> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
