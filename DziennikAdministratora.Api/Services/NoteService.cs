using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DziennikAdministratora.Api.ViewModels.NoteViewModel;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;

namespace DziennikAdministratora.Api.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepo _noteRepo;
        private readonly IMapper _mapper;

        public async Task AddNewNote(AddNoteViewModel model)
        {
            var note = new Note(Guid.NewGuid(), model.UserId, model.Subject, model.Body);
            await _noteRepo.AddNoteAsync(note);
        }

        public async Task EditNote(AddNoteViewModel model)
        {
            var note = await _noteRepo.GetNoteByIdAsync(model.UserId);
            if(note == null)
            {   
                throw new Exception("Notatka nie istnieje w bazie!");
            }
            if (note.UserId != model.UserId)
            {
                throw new Exception("Nie można edytowac notatki. Zle uprawnienia!");
            }

            note.SetSubject(model.Subject);
            note.SetBody(model.Body);

            await _noteRepo.UpdateNoteAsync(note);
        }

        public async Task<IEnumerable<NoteViewModel>> GetNotes()
        {
            var notes = await _noteRepo.GetNotesAsync();
            return _mapper.Map<IEnumerable<NoteViewModel>>(notes);
        }

        public async Task RemoveNote(Guid noteId)
        {
            await _noteRepo.RemoveNoteAsync(noteId);
        }
    }
}