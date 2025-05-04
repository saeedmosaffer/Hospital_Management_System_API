using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystemAPI.Models;

namespace HospitalManagementSystemAPI.Models
{
    [PrimaryKey(nameof(UserId), nameof(RoleId))]

    public class UserRole
    {
        // Composite key: UserId + RoleId
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}