using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.QuestionRepo;

namespace Hospital.Service
{
    public class QuestionService
    {
        private int _id;
        private readonly IQuestionRepository _repository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _repository = questionRepository;
            List<Question> questions = Read();
            if (questions.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = questions.Last().Id;
            }
        }

        public Question ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Question newQuestion)
        {
            newQuestion.Id = GenerateId();
            _repository.Create(newQuestion);
        }

        public void Edit(Question editQuestion)
        {
            _repository.Edit(editQuestion);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Question> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }
    }
}
