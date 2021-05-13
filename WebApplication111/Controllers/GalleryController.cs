using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;

namespace WebApplication111.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext context;
        public GalleryController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void AddPhoto(Photo photo, string companyId)
        {
            photo.Company = context.Companies.Find(companyId);
            photo.Company.UpdatedDay = DateTime.Now;
            context.Galery.Add(photo);
            context.SaveChanges();
        }

        [HttpDelete]
        public void DeletePhoto(string id)
        {
            var photo = context.Galery.Find(id);
            context.Galery.Remove(photo);
            context.SaveChanges();
        }

    }
}
