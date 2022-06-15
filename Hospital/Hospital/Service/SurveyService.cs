using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.SurveyRepo;

namespace Hospital.Service
{
    public class SurveyService
    {
        private int _id;
        private readonly ISurveyRepository _repository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _repository = surveyRepository;
            List<Survey> surveys = Read();
            if (surveys.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = surveys.Last().Id;
            }
        }

        public Survey ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Survey newSurvey)
        {
            newSurvey.Id = GenerateId();
            _repository.Create(newSurvey);
        }

        public void Edit(Survey editSurvey)
        {
            _repository.Edit(editSurvey);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Survey> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
