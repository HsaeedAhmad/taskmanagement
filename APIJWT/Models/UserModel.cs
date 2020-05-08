using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIJWT.Models
{
    public class UserModel
    {

        public int  UserId { get; set; }
        public string LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public UserRole UserRole { get; set; }
    }
}
