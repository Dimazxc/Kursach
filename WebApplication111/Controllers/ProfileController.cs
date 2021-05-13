using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;

namespace WebApplication111.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext context;
        public ProfileController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            this.context = context;
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        public  JsonResult GetCurrentUser()
        {
            var currentUser =  _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            return Json(currentUser);
        }
        
        public async Task<IActionResult> ReadOnlyCmp(string id)
        {
            var company = await context.Companies.FindAsync(id);
            return View(company);
        }

        [Authorize]
        public async Task<IActionResult> ViewCompany(string id)
        {
            var user = _userManager.GetUserAsync(User).GetAwaiter().GetResult();
            var company = await context.Companies.FindAsync(id);
            if (User.IsInRole("Admin") || company.UserId == user.Id) return View(company);
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, IdentityUser newUser)
        {
            var user = await _userManager.FindByIdAsync(id);
            user.UserName = newUser.UserName;
            user.PhoneNumber = newUser.PhoneNumber;
            user.Email = newUser.Email;
            if (!string.IsNullOrEmpty(user.Email)) await _userManager.UpdateAsync(user);
            return RedirectToAction("Privacy");
        }

        public IActionResult CancelEdit()
        {
            return RedirectToAction("Privacy");
        }
    }
}
