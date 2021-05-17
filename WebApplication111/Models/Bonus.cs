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
    [Table("Bonus")]
    public class Bonus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public float Price { get; set; }

        public Company Company { get; set; }

        [JsonIgnore]
        [JsonInclude]
        [IgnoreDataMember]
        public ICollection<UserBonus> UserBonuses { get; set; }
    }
}
