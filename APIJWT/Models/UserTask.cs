using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime ComplationDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int AssignFrom { get; set; }
        public int AssignTo { get; set; }
    }
}
