using System;
using System.Collections.Generic;

namespace Learning.NetCore.Domain.Entities
{
    public class RoleMenu : Entity
    {
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }
    }
}
