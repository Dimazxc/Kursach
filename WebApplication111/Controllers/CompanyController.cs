using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication111.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication111.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext context;
        public CompanyController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetCompanies(string userId)
        {
            var companies = context.Companies.Where(i => i.UserId == userId).ToList();
            return Json(companies);
        }

        public void AddCompany(Company company)
        {
            company.UpdatedDay = DateTime.Now;
            context.Companies.Add(company);
            context.SaveChanges();
        }

        public void DeleteCompany(string id)
        {
            var deleteCompany = context.Companies.Include(i => i.Bonuses).Include(i => i.Gallery).Include(i => i.News).
                Include(i => i.Ratings).Include(i => i.Comments).First(i => i.Id == id);
            var comments = context.Comments.Include(i => i.Company).Include(i => i.CommentRatings).Where(i => i.Company.Id == id);
            context.Comments.RemoveRange(comments);
            context.Companies.Remove(deleteCompany);
            context.SaveChanges();
        }

        public void UpdateCompany(string jsonCompany)
        {
            Company updateCompany = JsonConvert.DeserializeObject<Company>(jsonCompany);
            updateCompany.UpdatedDay = DateTime.Now;
            context.Companies.Update(updateCompany);
            context.SaveChanges();
        }

        public void UpdateDescription(string companyId, string newDescription, string imageUrl)
        {
            var company = context.Companies.Find(companyId);
            company.UpdatedDay = DateTime.Now;
            company.Description = newDescription;
            company.UrlImage = imageUrl;
            context.SaveChanges();
        }

        public JsonResult AddDonateCompany(string companyId, float donateSum)
        {
            var company = context.Companies.Find(companyId);
            return UpdateCompanyBalance(company, donateSum);
        }

        public JsonResult AddUserBonus(UserBonus userBonus, string bonusId)
        {
            var bonus = context.Bonuses.Include(i => i.Company).FirstOrDefault(i => i.Id == bonusId);
            userBonus.Bonus = bonus;
            context.UsersBonuses.Add(userBonus);
            return UpdateCompanyBalance(bonus.Company, bonus.Price);
        }

        private JsonResult UpdateCompanyBalance(Company company, float donateSum)
        {
            company.Balance += donateSum;
            context.SaveChanges();
            return Json(company.Balance);
        }

        public JsonResult ParseCompaniesTags()
        {
            StringBuilder alltags = new StringBuilder();
            List<string> tags = new List<string>();
            var companies = context.Companies.ToList();
            companies.ForEach(i => alltags.Append(i.Tags));
            tags.AddRange(alltags.ToString().Split(';').Distinct().SkipLast(1));
            return Json(tags);
        }

    }
}
