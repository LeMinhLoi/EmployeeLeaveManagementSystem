using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Configurations
{
    public class LeaveRequestConfiguration : IEntityTypeConfiguration<LeaveRequest>
    {
        public void Configure(EntityTypeBuilder<LeaveRequest> builder)
        {
            builder.ToTable("LeaveRequests");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.LeaveTypeId).IsRequired();
            builder.Property(e => e.StartDate).IsRequired();
            builder.Property(e => e.EndDate).IsRequired();
            builder.Property(e => e.DateRequested).IsRequired();
            builder.Property(e => e.RequestComments).IsRequired(false);
            builder.Property(e => e.Approved).IsRequired(false);
            builder.Property(e => e.Cancelled).IsRequired();
            builder.Property(e => e.RequestingEmployeeId).IsRequired();
            builder.HasOne(x => x.LeaveType).WithMany(x => x.LeaveRequests).HasForeignKey(x => x.LeaveTypeId);
        }
    }
}
