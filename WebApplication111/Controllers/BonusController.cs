using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication111.Data;
using WebApplication111.Models;

namespace WebApplication111.Controllers
{
    public class BonusController : Controller
    {
        private readonly ApplicationDbContext context;
        public BonusController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AddBonus(Bonus bonus, int companyId)
        {
            UpdateBonusCompany(bonus, companyId);
            context.Bonuses.Add(bonus);
            context.SaveChanges();

            return Ok(bonus.Id);
        }

        [HttpPost]
        public bool UpdateBonus(Bonus bonus, int companyId)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (TakeUserBonusCount(bonus.Id) > 0) return false;
            UpdateBonusCompany(bonus, companyId);
            context.Bonuses.Update(bonus);
            context.SaveChanges();
            return true;
        }

        private void UpdateBonusCompany(Bonus bonus, int companyId)
        {
            bonus.Company = context.Companies.Find(companyId);
            bonus.Company.UpdatedDay = DateTime.Now;
        }

        [HttpPost]
        public bool DeleteBonus(int id)
        {
            var bonus = context.Bonuses.Include(i => i.UserBonuses).First(i => i.Id == id);
            if (TakeUserBonusCount(id) > 0) return false;
            context.Bonuses.Remove(bonus);
            context.SaveChanges();
            return true;
        }

        private int TakeUserBonusCount(int bonusId)
        {
            var bonus = context.Bonuses.Include(i => i.UserBonuses).First(i => i.Id == bonusId);
            return bonus.UserBonuses.Count();
        }
    }
}
