using System.Collections.Generic;
using Hospital.Model;

namespace Hospital.Repository.NoteRepo
{
    public interface INoteRepository : IRepositoryBase<Note, int>
    {
        List<Note> ReadByPatientId(int id);
    }
}