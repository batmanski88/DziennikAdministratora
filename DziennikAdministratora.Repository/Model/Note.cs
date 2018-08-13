using System;

namespace DziennikAdministratora.Repository.Model
{
    public class Note
    {
        public Guid NoteId { get; protected set; }
        public Guid UserId { get; protected set; }
        public Guid CategoryId { get; protected set; }
        public string Subject { get; protected set; }
        public string Body { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public virtual User User { get; protected set; }

        protected Note()
        {

        }
        
        public Note(Guid noteId, Guid userId, Guid categoryId, string subject, string body)
        {
            NoteId = noteId;
            UserId = userId;
            CategoryId = categoryId;
            Subject = subject;
            Body = body;
            CreatedAt = DateTime.UtcNow;
        }

        
    }
}