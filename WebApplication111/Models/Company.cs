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
    [Table("Company")]
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UrlVideo { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [Required]
        public string Tags { get; set; }

        [Required]
        public float Balance { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public DateTime EndDay { get; set; }

        [Required]
        public DateTime UpdatedDay { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public string UserId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<News> News { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Bonus> Bonuses { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Photo> Gallery { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]

        public ICollection<Comment> Comments { get; set; }

        [JsonIgnore]
        [JsonInclude]
        [IgnoreDataMember]
        public ICollection<CompanyRating> Ratings { get; set; }
    }
}
