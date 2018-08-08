using System;

namespace DziennikAdministratora.Api.ViewModels.NoteViewModel
{
    public class NoteViewModel
    {
        public Guid NoteId {get; set;}
        public Guid CateogryId {get; set;}
        public Guid UserId {get; set;}
        public string Subject {get; set;}
        public string Body {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdateAt {get; set;}
    }
}