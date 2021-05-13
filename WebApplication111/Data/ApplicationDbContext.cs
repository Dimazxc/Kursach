using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication111.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Bonus> Bonuses { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Photo> Galery { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CompanyRating> Ratings { get; set; }

        public DbSet<CommentRating> CommentRatings { get; set; }

        public DbSet<UserBonus> UsersBonuses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
    }
}
