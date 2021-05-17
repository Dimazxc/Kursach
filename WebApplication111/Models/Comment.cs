using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication111.Data
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public uint Likes { get; set; }

        [Required]
        public uint Dislikes { get; set; }

        [Required]
        public string UserId { get; set; }

        public Company Company { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<CommentRating> CommentRatings { get; set; }
    }
}
