using Project.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class LeaveType : IDateTracking
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public List<LeaveRequest>? LeaveRequests { get; set; }
        public List<LeaveAllocation>? LeaveAllocations { get; set; }
    }
}
