using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManageSolution.Models;
using TaskManageSolution.Services;
using TaskManageSolution.Interfaces;
using TaskManagement.Models;
using TaskManageSolution.Infrastructure;
using AspNetCore;

namespace TaskManageSolution.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser user;
        
        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(user.GetAll());
           
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
              

            return View(user.Getbyid(id));
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,LoginId,UserName,Password,Email,CreateDate,RoleId,CreatedBy,IsDeleted")] Users users)
        {
            if (ModelState.IsValid)
            {
                user.Insert(users);
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = user.Getbyid(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,LoginId,UserName,Password,Email,CreateDate,RoleId,CreatedBy,IsDeleted")] Users users)
        {
            if (id != users.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    user.Update(users);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Users a = new Users();
            a.UserId = id;
             user.Delete(a);
          
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Users a = new Users();
            a.UserId = id;
            user.Delete(a);
            return RedirectToAction(nameof(Index));
        }

     
    }
}
