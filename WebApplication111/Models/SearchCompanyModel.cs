using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication111.Models
{
    public class SearchCompanyModel
    {
        public string Id { get; set; }

        public string Name { get; set;}

        public SearchCompanyModel(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
