using System;
using System.Threading.Tasks;
using DziennikAdministratora.Api.Services;
using DziennikAdministratora.Api.ViewModels.NoteViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DziennikAdministratora.Api.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        [HttpGet]
        [Route("api/Note/GetNotes")]
        public async Task<IActionResult> GetNotes()
        {
            var notes = await _noteService.GetNotes();
            return Ok(notes);
        }

        [HttpPost]
        [Route("api/Note/AddNote")]
        public async Task<IActionResult> AddNote([FromBody]AddNoteViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _noteService.AddNewNote(model);
            return CreatedAtAction("GetNotes", new { id = model.NoteId });
        }

        [HttpPut]
        [Route("api/Note/UpdateNote")]
        public async Task<IActionResult> UpdateNote([FromBody]AddNoteViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _noteService.EditNote(model);
            return Ok();
        }

        [HttpDelete]
        [Route("api/Note/DeleteNote/{Id}")]
        public async Task<IActionResult> DeleteNote(Guid Id)
        {
            await _noteService.RemoveNote(Id);
            return NoContent();
        }

        [HttpGet]
        [Route("api/Note/GetRole/{Id}")]
        public async Task<IActionResult> GetRole(Guid Id)
        {
            await _noteService.GetNoteByIdAsync(Id);
            return Ok();
        }
    }
}