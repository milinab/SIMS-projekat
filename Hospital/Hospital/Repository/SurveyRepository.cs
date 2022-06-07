using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class SurveyRepository
    {
        private ObservableCollection<Survey> _surveys;
        private readonly Serializer<Survey> _serializer;

        public SurveyRepository()
        {
            _serializer = new Serializer<Survey>("surveys.csv");
            _surveys = new ObservableCollection<Survey>();
        }

        public ObservableCollection<Survey> Read()
        {
            _surveys = _serializer.Read();
            return _surveys;
        }

        public Survey ReadById(int id)
        {
            foreach (Survey survey in _surveys)
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
            _surveys.Add(newSurvey);
            Write();
        }

        public void Edit(Survey editSurvey)
        {
            foreach (Survey survey in _surveys)
            {
                if (editSurvey.Id.Equals(survey.Id))
                {
                    survey.Name = editSurvey.Name;
                    survey.ExpirationDate = editSurvey.ExpirationDate;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _surveys.Count - 1; i >= 0; i--)
            {
                if (_surveys[i].Id.Equals(id))
                {
                    _surveys.Remove(_surveys[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_surveys);
        }
    }
}
