using System;

namespace DziennikAdministratora.Repository.Model
{
    public class Note
    {
        public Guid NoteId { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Subject { get; protected set; }
        public string Body { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public virtual User User { get; protected set; }

        protected Note()
        {

        }
        
        public Note(Guid noteId, Guid userId, string subject, string body)
        {
            NoteId = noteId;
            UserId = userId;
            Subject = subject;
            Body = body;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUserId(Guid userId)
        {
            if(UserId == userId)
            {
                return;
            }
            UserId = userId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetSubject(string subject)
        {
            if(Subject == subject)
            {
                return;
            }
            Subject = subject;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetBody(string body)
        {
            if(Body == body)
            {
                return;
            }
            Body = body;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}