﻿using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class QuestionRepository
    {
        private ObservableCollection<Question> _questions;
        private readonly Serializer<Question> _serializer;
        private readonly QuestionRepository _questionsRepository;

        public QuestionRepository()
        {
            _serializer = new Serializer<Question>("questions.csv");
            _questions = new ObservableCollection<Question>();
        }

        public QuestionRepository(QuestionRepository questionRepository)
        {
            _serializer = new Serializer<Question>("questions.csv");
            _questions = new ObservableCollection<Question>();
            _questionsRepository = questionRepository;
        }

        public ObservableCollection<Question> Read()
        {
            _questions = _serializer.Read();
            return _questions;
        }

        public Question ReadById(int id)
        {
            foreach (Question question in _questions)
            {
                if (question.Id.Equals(id))
                {
                    return question;
                }
            }
            return null;
        }

        public void Create(Question newQuestion)
        {
            _questions.Add(newQuestion);
            Write();
        }

        public void Edit(Question editQuestion)
        {
            foreach (Question question in _questions)
            {
                if (editQuestion.Id.Equals(question.Id))
                {
                    question.QuestionText = editQuestion.QuestionText;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _questions.Count - 1; i >= 0; i--)
            {
                if (_questions[i].Id.Equals(id))
                {
                    _questions.Remove(_questions[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_questions);
        }
    }
}