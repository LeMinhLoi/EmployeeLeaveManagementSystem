using Project.Data.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class LeaveAllocation : IDateTracking
    {
        public Guid Id { get; set; }

        public int NumberOfDays { get; set; }

        public Guid LeaveTypeId { get; set; }

        public LeaveType? LeaveType { get; set; }

        public Guid EmployeeId { get; set; }

        public int Period { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }
    }
}
