using Project.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class LeaveRequest : IDateTracking
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public LeaveType? LeaveType { get; set; }

        public Guid LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        public string? RequestComments { get; set; }

        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }

        public Guid RequestingEmployeeId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
