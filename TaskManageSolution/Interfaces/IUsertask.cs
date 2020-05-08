using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Models;

namespace TaskManageSolution.Interfaces
{
    interface IUsertask
    {
        List<UserTask> GetAll();
        UserTask Getbyid(int id);
        void Update(UserTask users);
        void Delete(UserTask users);
        void Insert(UserTask users);
        void Save();
    }
}
