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

namespace WebApplication111.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Test(string information)
        {
            var soughtCompanies = new List<SearchCompanyModel>();      
            var companies = context.Companies.FullTextSearchQuery(information).Select(i => new SearchCompanyModel(i.Id, i.Name)).ToList();
            var companiesNews = context.News.FullTextSearchQuery(information).Select(i => new SearchCompanyModel(i.Company.Id, i.Company.Name)).ToList();
            var companiesBonuses = context.Bonuses.FullTextSearchQuery(information).Select(i => new SearchCompanyModel(i.Company.Id, i.Company.Name)).ToList();
            var companiesComments = context.Comments.FullTextSearchQuery(information).Select(i => new SearchCompanyModel(i.Company.Id, i.Company.Name)).ToList();
            soughtCompanies = companies.Concat(companiesNews).Concat(companiesBonuses).Concat(companiesComments).DistinctBy(i => i.Id).ToList();

            return Json(soughtCompanies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
