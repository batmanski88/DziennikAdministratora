using System;

namespace DziennikAdministratora.Repository.Model
{
    public class UserInRole
    {
        public Guid UserId {get; set;}
        public Guid RoleId {get; set;}
        public User User {get; set;}
        public Role Role {get; set;}

        protected UserInRole()
        {
            
        }
        public UserInRole( Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}