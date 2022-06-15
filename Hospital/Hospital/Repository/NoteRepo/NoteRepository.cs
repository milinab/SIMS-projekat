using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.Model;

namespace Hospital.Repository.NoteRepo
{
    public class NoteRepository : INoteRepository
    {
        private readonly Serializer<Note> _serializer;

        public NoteRepository()
        {
            _serializer = new Serializer<Note>("notes.csv");
        }

        public List<Note> Read()
        {
            return _serializer.Read();
        }

        public Note ReadById(int id)
        {
            return Read().FirstOrDefault(note => note.Id.Equals(id));
        }

        public void Create(Note newNote)
        {
            var list = Read();
            list.Add(newNote);
            Write(list);
        }

        public void Edit(Note editNote)
        {
            var list = Read();
            foreach (var note in list.Where(note => editNote.Id.Equals(note.Id)))
            {
                note.Name = editNote.Name;
                note.NoteText = editNote.NoteText;
                note.Date = editNote.Date;
                note.NotificationDate = editNote.NotificationDate;
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

        public void Write(List<Note> list)
        {
            _serializer.Write(list);
        }

        public List<Note> ReadByPatientId(int patientId)
        {
            return Read().Where(note => note.PatientId.Equals(patientId)).ToList();
        }
    }
}
