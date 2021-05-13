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
using Microsoft.EntityFrameworkCore;

namespace WebApplication111.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly DateTime endBlockDay;
        public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
            this.endBlockDay = new DateTime(2221, 06, 06);
        }

        [HttpGet]
        public IActionResult UserTable()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserCompaniesTable(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return View(user);
        }

        public async Task<IActionResult> MakeAdmin(string[] usersId)
        {
            foreach (var id in usersId)
            {
                var user = await userManager.FindByIdAsync(id);
                await userManager.RemoveFromRoleAsync(user, "User");
                await userManager.AddToRoleAsync(user, "Admin");
            }

            return Ok();
        }

        public async Task<IActionResult> DeleteUsers(string[] usersId)
        {
            foreach (var id in usersId)
            {
                var user = await userManager.FindByIdAsync(id);
                var userCompanies = await context.Companies.Where(i => i.UserId == id).ToListAsync(); ;
                if (userCompanies.Count == 0)
                {
                    var logins = await userManager.GetLoginsAsync(user);
                    foreach (var login in logins) await userManager.RemoveLoginAsync(user, login.LoginProvider, login.ProviderKey);
                    await userManager.RemoveFromRoleAsync(user, "User");
                    await userManager.DeleteAsync(user);
                }
            }

            return Ok();
        }

        public async Task<IActionResult> LockUsers(string[] userId)
        {
            foreach (var id in userId)
            {
                var user = await userManager.FindByIdAsync(id);
                await userManager.SetLockoutEnabledAsync(user, true);
                await userManager.SetLockoutEndDateAsync(user, endBlockDay);
                await userManager.UpdateSecurityStampAsync(user);
                await userManager.UpdateAsync(user);
            }

            return Ok();
        }

        public async Task<IActionResult> UnlockUsers(string[] userId)
        {
            foreach (var id in userId)
            {
                var user = await userManager.FindByIdAsync(id);
                await userManager.SetLockoutEndDateAsync(user, DateTime.Now);
                await userManager.SetLockoutEnabledAsync(user, false);
                var result = await userManager.UpdateAsync(user);
            }

            return Ok();
        }

        public async Task<JsonResult> GetUsers()
        {
            var users = await userManager.GetUsersInRoleAsync("User");
            return Json(users);
        }
    }
}
