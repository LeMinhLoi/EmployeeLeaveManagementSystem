using Microsoft.AspNetCore.Identity;
using Project.Common.Constants;
using Project.Data.Abstracts;

namespace Project.Data.Entities
{
    public class Employee : IdentityUser<Guid>, IDateTracking
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateJoined { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
