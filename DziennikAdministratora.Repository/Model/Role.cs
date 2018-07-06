using System;
using System.Collections.Generic;

namespace DziennikAdministratora.Repository.Model
{
    public class Role
    {
        public Guid RoleId {get; protected set;}
        public string Name {get; protected set;}
        public ICollection<UserInRole> UsersInRoles {get; set;}
        
        protected Role()
        {

        }

        public Role(Guid roleId, string name)
        {
            RoleId = roleId;
            Name = name;
            this.UsersInRoles = new HashSet<UserInRole>();
        }

        public void SetRoleId(Guid roleId)
        {
            RoleId = roleId;
        }
        public void SetName(string name)
        {
            if(Name == name)
            {
                return;
            }
            Name = name;
        }
    }
}