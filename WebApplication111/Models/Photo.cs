using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication111.Data
{
    [Table("Photo")]
    public class Photo
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Title { get; set; }

        public Company Company { get; set; }
    }
}
