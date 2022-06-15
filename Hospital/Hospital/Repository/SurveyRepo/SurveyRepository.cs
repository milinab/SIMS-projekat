using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.SurveyRepo
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly Serializer<Survey> _serializer;

        public SurveyRepository()
        {
            _serializer = new Serializer<Survey>("surveys.csv");
        }

        public List<Survey> Read()
        {
            return _serializer.Read();
        }

        public Survey ReadById(int id)
        {
            foreach (Survey survey in Read())
            {
                if (survey.Id.Equals(id))
                {
                    return survey;
                }
            }
            return null;
        }

        public void Create(Survey newSurvey)
        {
            var list = Read();
            list.Add(newSurvey);
            Write(list);
        }

        public void Edit(Survey editSurvey)
        {
            var list = Read();
            foreach (Survey survey in list)
            {
                if (editSurvey.Id.Equals(survey.Id))
                {
                    survey.Name = editSurvey.Name;
                    survey.ExpirationDate = editSurvey.ExpirationDate;
                }
            }
            Write(list);
        }
        public void Delete(int id)
        {
            var list = Read();
            foreach (var resp in list.Where(resp => resp.Id == id))
            {
                list.Remove(resp);
            }
            Write(list);
        }

        public void Write(List<Survey> list)
        {
            _serializer.Write(list);
        }
    }
}
