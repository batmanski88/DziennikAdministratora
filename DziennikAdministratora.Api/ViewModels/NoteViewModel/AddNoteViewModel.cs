using System;

namespace DziennikAdministratora.Api.ViewModels.NoteViewModel
{
    public class AddNoteViewModel
    {
        public Guid UserId {get; set;}
        public string Subject {get; set;}
        public string Body {get; set;}
    }
}