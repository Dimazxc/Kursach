using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Controllers.SignalRHub;
using WebApplication111.Data;
using WebApplication111.Models;

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
        public IActionResult AddComment(Comment comment, int companyId)
        {
            comment.Company = context.Companies.Find(companyId);
            context.Comments.Add(comment);
            context.SaveChanges();

            return Ok(comment.Id);
        }
    }
}
