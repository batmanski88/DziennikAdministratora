using System;
using System.Collections.Generic;

namespace DziennikAdministratora.Repository.Model
{
    public class User
    {
        public Guid UserId {get; protected set;}
        public string Email { get; protected set;}
        public string Password {get; protected set;}
        public string Salt {get; protected set;}
        public string UserName {get; protected set;}
        public DateTime UpdateAt {get; protected set;}
        public DateTime CreateAt {get; protected set;}
        public ICollection<UserInRole> UserInRoles {get; set;}

        protected User()
        {

        }

        public User(Guid userId, string email, string password, string salt)
        {
            UserId = userId;
            Email = email;
            Password = password;
            Salt = salt;
            CreateAt = DateTime.UtcNow;
            this.UserInRoles = new HashSet<UserInRole>();
        }

        public void SetEmail(string email)
        {
            if(Email == email)
            {
                return;
            }
            Email = email;
            UpdateAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if(Password == password)
            {
                return;
            }
            Password = password;
            Salt = salt;
            UpdateAt = DateTime.UtcNow;
        }

        public void SetUserName(string userName)
        {
            if(UserName == userName)
            {
                return;
            }
            UserName = userName;
            UpdateAt = DateTime.UtcNow;
        }
    }
}