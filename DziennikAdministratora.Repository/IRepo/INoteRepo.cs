using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Repository.IRepo
{
    public interface INoteRepo
    {
         Task<Note> GetNoteByIdAsync(Guid noteId);
         Task<IEnumerable<Note>> GetNotesAsync();
         Task AddNoteAsync(Note note);
         Task RemoveNoteAsync(Guid noteId);
         Task UpdateNoteAsync(Note note);
    }
}