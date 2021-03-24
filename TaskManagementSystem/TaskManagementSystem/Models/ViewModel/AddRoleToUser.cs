using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class AddRoleToUser
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
