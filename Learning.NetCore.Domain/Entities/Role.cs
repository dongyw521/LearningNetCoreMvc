using System;
using System.Collections.Generic;

namespace Learning.NetCore.Domain.Entities
{
    public class Role:Entity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Remarks { get; set; }

        public virtual User CreateUser { get; set; }

        //public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<RoleMenu> Menus { get; set; }
    }
}