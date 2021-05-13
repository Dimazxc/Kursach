using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Threading.Tasks;
using WebApplication111.Data;
using WebApplication111.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication111.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;

        public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        [HttpGet]
        public IActionResult UserTable()
        {
            return View();
        }

        public async void MakeAdmin(string[] usersId)
        {
            foreach (var id in usersId)
            {
                var user = await userManager.FindByIdAsync(id);
                await userManager.RemoveFromRoleAsync(user, "User");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }

        public async void DeleteUsers(string[] usersId)
        {
            foreach (var id in usersId)
            {
                var user = await userManager.FindByIdAsync(id);
                var userCompanies = context.Companies.Where(i => i.UserId == id);
                if (userCompanies.Count() != 0)
                {
                    await userManager.RemoveFromRoleAsync(user, "User");
                    await userManager.DeleteAsync(user);
                }
            }
        }

        public async void LockUsers(string[] userId)
        {
            foreach (var id in userId)
            {
                var user = await userManager.FindByIdAsync(id);
                user.LockoutEnabled = true;
            }
        }

        public async void UnlockUsers(string[] userId)
        {
            foreach (var id in userId)
            {
                var user = await userManager.FindByIdAsync(id);
                user.LockoutEnabled = false;
            }
        }

        public async Task<JsonResult> GetUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("User");
            return Json(users);
        }
    }
}
