using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication111.Models;

namespace WebApplication111.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext context;
        public NewsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void AddNews(News news, int companyId)
        {
            UpdateNewsCompany(news, companyId);
            news.Date = DateTime.Now;
            context.News.Add(news);
            context.SaveChanges();
        }

        [HttpPost]
        public void UpdateNews(News news, int companyId)
        {
            UpdateNewsCompany(news, companyId);
            news.Date = DateTime.Now;
            context.News.Update(news);
            context.SaveChanges();
        }

        private void UpdateNewsCompany(News news, int companyId)
        {
            news.Company = context.Companies.Find(companyId);
            news.Company.UpdatedDay = DateTime.Now;
        }

        [HttpPost]
        public void DeleteNews(string id)
        {
            var news = context.News.Find(id);
            context.News.Remove(news);
            context.SaveChanges();
        }
    }
}
