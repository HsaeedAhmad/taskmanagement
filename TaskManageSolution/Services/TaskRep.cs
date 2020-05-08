using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManageSolution.Interfaces;
using TaskManageSolution.Models;

namespace TaskManageSolution.Services
{
    public class TaskRep : IUsertask
    {
        private readonly ApplicationDbContext _context;

        public TaskRep(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(UserTask users)
        {

            _context.UserTask.Remove(users);
                
        }
        public List<UserTask> GetAll()
        {
            return _context.UserTask.ToList();
        }

        public UserTask Getbyid(int id)
        {
            return _context.UserTask
         .Where(m => m.Id == id).FirstOrDefault();
        }
        public void Insert(UserTask users)
        {
                _context.UserTask.Add(users);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(UserTask users)
        {
            _context.UserTask.Update(users);
        }
    }
}
