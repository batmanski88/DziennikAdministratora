using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikAdministratora.Repository.IRepo;
using DziennikAdministratora.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace DziennikAdministratora.Repository.Repo
{
    public class NoteRepo : INoteRepo
    {
        private readonly IAppDbContext _context;

        public NoteRepo(IAppDbContext context)
        {
            _context = context;
        }

        public async Task AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task<Note> GetNoteByIdAsync(Guid noteId)
        {
            var notes = await _context.Notes.ToListAsync();
            return notes.Where(x => x.NoteId == noteId).FirstOrDefault();
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task RemoveNoteAsync(Guid noteId)
        {
            var notes = await _context.Notes.ToListAsync();
            _context.Notes.Remove(notes.Where(x => x.NoteId == noteId).FirstOrDefault());
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNoteAsync(Note note)
        {
            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}