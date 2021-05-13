using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication111.Data
{
    [Table("CompanyRating")]
    public class CompanyRating
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string UserId { get; set; }

        public Company Company { get; set; }
    }
}
