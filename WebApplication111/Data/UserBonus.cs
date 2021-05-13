using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication111.Data
{
    [Table("UserBonus")]
    public class UserBonus
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        public Bonus Bonus { get; set; }
    }
}
