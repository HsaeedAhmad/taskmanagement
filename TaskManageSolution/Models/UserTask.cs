using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Models
{
    public class UserTask
    {
        [Key]
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime AssignDate { get; set; } = DateTime.Now;
        public DateTime ComplationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int AssignBy { get; set; }


    }
}
