using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication111.Data;
using WebApplication111.Models;

namespace WebApplication111.Controllers
{
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext context;
        public RatingController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult AddOrUpdateRating(CompanyRating rate, int companyId)
        {
            if (!context.Ratings.Include(i => i.Company).Any(i => rate.Id == i.Id && i.Company.Id == companyId))
            {
                rate.Company = context.Companies.Find(companyId);
                context.Ratings.Add(rate);
            }
            else
            {
                context.Ratings.Update(rate);
            }
            context.SaveChanges();
            var ratingsCompany = context.Ratings.Include(i => i.Company).Where(i => i.Company.Id == companyId).ToList();
            return Json(ratingsCompany);
        }

        public JsonResult GetUserRating(string userId, int companyId)
        {
            var userRating = context.Ratings.FirstOrDefault(r => r.UserId == userId && r.Company.Id == companyId);
            return Json(userRating);
        }

        public JsonResult GetCompanyRating(int companyId)
        {
            return Json(context.Ratings.Where(rs => rs.Company.Id == companyId).ToList());
        }
    }
}
