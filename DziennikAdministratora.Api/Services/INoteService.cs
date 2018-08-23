using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DziennikAdministratora.Api.ViewModels.NoteViewModel;

namespace DziennikAdministratora.Api.Services
{
    public interface INoteService
    {
        Task AddNewNote(AddNoteViewModel model);
        Task EditNote(AddNoteViewModel model);
        Task RemoveNote(Guid noteId);
        Task<IEnumerable<NoteViewModel>> GetNotes();
    }
}