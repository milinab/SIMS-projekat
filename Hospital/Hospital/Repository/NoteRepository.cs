using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Repository
{
    public class NoteRepository
    {
        private ObservableCollection<Note> _notes;
        private readonly Serializer<Note> _serializer;

        public NoteRepository()
        {
            _serializer = new Serializer<Note>("notes.csv");
            _notes = new ObservableCollection<Note>();
        }

        public ObservableCollection<Note> Read()
        {
            _notes = _serializer.Read();
            return _notes;
        }

        public Note ReadById(int id)
        {
            foreach (Note note in _notes)
            {
                if (note.Id.Equals(id))
                {
                    return note;
                }
            }
            return null;
        }

        public void Create(Note newNote)
        {
            _notes.Add(newNote);
            Write();
        }

        public void Edit(Note editNote)
        {
            foreach (Note note in _notes)
            {
                if (editNote.Id.Equals(note.Id))
                {
                    note.Name = editNote.Name;
                    note.NoteText = editNote.NoteText;
                    note.Date = editNote.Date;
                    note.NotificationDate = editNote.NotificationDate;
                }
            }
            Write();
        }

        public void Delete(int id)
        {
            for (int i = _notes.Count - 1; i >= 0; i--)
            {
                if (_notes[i].Id.Equals(id))
                {
                    _notes.Remove(_notes[i]);
                }
            }
            Write();
        }

        public void Write()
        {
            _serializer.Write(_notes);
        }
    }
}
