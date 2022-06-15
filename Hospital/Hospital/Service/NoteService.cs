using System.Collections.Generic;
using System.Linq;
using Hospital.Model;
using Hospital.Repository.NoteRepo;

namespace Hospital.Service
{
    public class NoteService
    {
        private int _id;
        private readonly INoteRepository _repository;

        public NoteService(INoteRepository noteRepository)
        {
            _repository = noteRepository;
            List<Note> notes = Read();
            if (notes.Count == 0)
            {
                _id = 0;
            }
            else
            {
                _id = notes.Last().Id;
            }
        }

        public Note ReadById(int id)
        {
            return _repository.ReadById(id);
        }

        public void Create(Note newNote)
        {
            newNote.Id = GenerateId();
            _repository.Create(newNote);
        }

        public void Edit(Note editNote)
        {
            _repository.Edit(editNote);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Note> Read()
        {
            return _repository.Read();
        }

        private int GenerateId()
        {
            return ++_id;
        }

        public List<Note> ReadByPatientId(int patientId)
        {
            return _repository.ReadByPatientId(patientId);
        }
    }
}
