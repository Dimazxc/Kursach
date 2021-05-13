using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication111.Data
{
    [Table("CommentRating")]
    public class CommentRating
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public bool IsLike { get; set; }

        [Required]
        public string UserId { get; set; }

        public Comment Comment { get; set; }
    }
}
