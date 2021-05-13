using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;

namespace WebApplication111.Controllers
{
    public class CommentRatingController : Controller
    {
        private readonly ApplicationDbContext context;

        public CommentRatingController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public void AddCommentRating(CommentRating commentRating, string commentId)
        {
            var comment = context.Comments.Include(r => r.Company).FirstOrDefault(r => r.Id == commentId);
            var rating = context.CommentRatings.AsNoTracking().FirstOrDefault(r => r.UserId == commentRating.UserId && r.Comment.Id == commentId);
            commentRating.Comment = comment;
            if (rating == null) context.CommentRatings.Add(commentRating);
            else
            {
                commentRating.Id = rating.Id;
                context.CommentRatings.Update(commentRating);
            }
            context.SaveChanges();
            UpdateRatingCount(comment, context.CommentRatings.Include(r => r.Comment).Where(i => i.Comment.Id == comment.Id).ToList());
        }

        public void RemoveCommentRating(string userId, string commentId)
        {
            var commentRating = context.CommentRatings.Include(r => r.Comment).FirstOrDefault(r => r.UserId == userId && r.Comment.Id == commentId);
            context.CommentRatings.Remove(commentRating);
            context.SaveChanges();
            UpdateRatingCount(commentRating.Comment, context.CommentRatings.Include(r => r.Comment).Where(i => i.Comment.Id == commentRating.Comment.Id).ToList());
        }

        private void UpdateRatingCount(Comment comment, List<CommentRating> commentRatings)
        {
            comment.Likes = (uint)commentRatings.Where(i => i.IsLike).Count();
            comment.Dislikes =(uint)(commentRatings.Count() - comment.Likes);
            context.SaveChanges();
        }
        
        public JsonResult GetUserCommentRatings(string userId, string companyId)
        {
            var userCommentRatings = context.CommentRatings.Include(r => r.Comment).Where(i => i.UserId == userId && i.Comment.Company.Id == companyId);
            return Json(userCommentRatings);
        }
    }
}
