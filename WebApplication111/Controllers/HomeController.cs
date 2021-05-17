using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;
using WebApplication111.Models;
using Korzh.EasyQuery.Linq;
using MoreLinq;
using Microsoft.EntityFrameworkCore;
using SoftCircuits.FullTextSearchQuery;
using Newtonsoft.Json;

namespace WebApplication111.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        public HomeController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult SearchCompany(string searchTerm)
        {
            var cmp = context.Companies.Where(i => EF.Functions.Contains(i.Name, searchTerm) || EF.Functions.Contains(i.Description, searchTerm));
            var news = context.News.Include(i => i.Company).Where(i => EF.Functions.Contains(i.Content, searchTerm) || EF.Functions.Contains(i.Title, searchTerm)).Select(i => i.Company);
            var bonuses = context.Bonuses.Include(i => i.Company).Where(i => EF.Functions.Contains(i.Title, searchTerm)).Select(i => i.Company);
            var comments = context.Comments.Include(i => i.Company).Where(i => EF.Functions.Contains(i.Content, searchTerm) || EF.Functions.Contains(i.Title, searchTerm)).Select(i => i.Company);
            var soughtCompanies = cmp.Concat(news).Concat(bonuses).Concat(comments).DistinctBy(i => i.Id).ToList();
            return Json(soughtCompanies);
        }

        public JsonResult FilterCompany(string[] tags)
        {
            var soughtCompanies = new List<Company>();
            var companies = context.Companies.Include(i => i.Ratings).ToList();
            foreach (var tag in tags)
            {
                soughtCompanies.AddRange(companies.Where(i => i.Tags.Contains(tag)));
            }
            var jsonRatedCompanies = JsonConvert.SerializeObject(soughtCompanies.DistinctBy(i => i.Id).ToList(), Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = new IncludeIgnored(true) });
            return Json(jsonRatedCompanies);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
