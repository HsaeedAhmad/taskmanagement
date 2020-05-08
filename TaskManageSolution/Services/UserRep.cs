using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManageSolution.Infrastructure;
using TaskManageSolution.Models;

namespace TaskManageSolution.Services
{
    public class UserRep : IUser
    {
        private readonly ApplicationDbContext _context;

        public UserRep(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(Users users)
        {

            _context.Users.Remove(users);

        }
        public List<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        public Users Getbyid(int id)
        {
            return _context.Users
         .Where(m => m.UserId == id).FirstOrDefault();
        }
        public void Insert(Users users)
        {
            _context.Users.Add(users);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Users users)
        {
            _context.Users.Update(users);
        }
    }
}
