using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManageSolution.Models;

namespace TaskManageSolution.Infrastructure
{
   public interface IUser
    {
        List<Users> GetAll();
        Users Getbyid(int id);
        void Update(Users users);
        void Delete(Users users);
        void Insert(Users users);
        void Save();

    }
}
