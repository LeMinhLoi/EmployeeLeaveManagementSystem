using Microsoft.AspNetCore.Identity;
using Project.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class AppRole : IdentityRole<Guid>, IDateTracking
    {
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
