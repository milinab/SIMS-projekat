using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.QuestionRepo
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly Serializer<Question> _serializer;

        public QuestionRepository()
        {
            _serializer = new Serializer<Question>("questions.csv");
        }

        public List<Question> Read()
        {
            return _serializer.Read();
        }

        public Question ReadById(int id)
        {
            return Read().FirstOrDefault(question => question.Id == id);
        }

        public void Create(Question newQuestion)
        {
            var list = Read();
            list.Add(newQuestion);
            Write(list);
        }

        public void Edit(Question editQuestion)
        {
            var list = Read();
            foreach (var question in list.Where(question => editQuestion.Id.Equals(question.Id)))
            {
                question.QuestionText = editQuestion.QuestionText;
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

        public void Write(List<Question> list)
        {
            _serializer.Write(list);
        }
    }
}
