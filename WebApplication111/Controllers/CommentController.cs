using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Controllers.SignalRHub;
using WebApplication111.Data;

namespace WebApplication111.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext context;
        private IHubContext<CommentsHub> hubContext;
        public CommentController(ApplicationDbContext context, IHubContext<CommentsHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public void AddComment(Comment comment, string companyId)
        {
            comment.Company = context.Companies.Find(companyId);
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public JsonResult GetCompanyComment(string companyId)
        {
            var comments = context.Companies.ToList();
            return Json(comments);
        }
    }
}
