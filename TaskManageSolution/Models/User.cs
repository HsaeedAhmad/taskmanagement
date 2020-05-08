using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

    }
}
