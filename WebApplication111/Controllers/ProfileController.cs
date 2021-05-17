using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;
using WebApplication111.Models;

namespace WebApplication111.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        public ProfileController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        [Authorize]
        public IActionResult Privacy()
        {
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            return View(user);
        }

        public JsonResult GetCurrentUser()
        {
            var currentUser =  userManager.GetUserAsync(User).GetAwaiter().GetResult();
            return Json(currentUser);
        }
        
        [Authorize]
        public async Task<IActionResult> ViewCompany(int id)
        {
            var user = userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var company = await context.Companies.FindAsync(id);
            if (User.IsInRole("Admin") || company.UserId == user.Id) return View(company);
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, IdentityUser newUser)
        {
            var user = await userManager.FindByIdAsync(id);
            user.UserName = newUser.UserName;
            user.PhoneNumber = newUser.PhoneNumber;
            user.Email = newUser.Email;
            await userManager.UpdateAsync(user);
            return RedirectToAction("Privacy");
        }

        public IActionResult CancelEdit()
        {
            return RedirectToAction("Privacy");
        }
    }
}
