using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
    public class NoteController
    {
        private readonly NoteService _service;

        public NoteController(NoteService service)
        {
            _service = service;
        }

        public Note ReadById(int id)
        {
            return _service.ReadById(id);
        }

        public void Create(Note newNote)
        {
            _service.Create(newNote);
        }

        public void Edit(Note editNote)
        {
            _service.Edit(editNote);
        }

        public void Delete(int id)
        {
            _service.Delete(id);
        }

        public ObservableCollection<Note> Read()
        {
            return _service.Read();
        }

        public ObservableCollection<Note> ReadByPatientId(int patientId)
        {
            return _service.ReadByPatientId(patientId);
        }
    }
}
