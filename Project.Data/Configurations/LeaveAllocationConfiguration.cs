using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Entities;

namespace Project.Data.Configurations
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            builder.ToTable("LeaveAllocations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NumberOfDays).IsRequired();
            builder.Property(x => x.EmployeeId).IsRequired();
            builder.Property(x => x.Period).IsRequired();
            builder.Property(x => x.LeaveTypeId).IsRequired();
            builder.HasOne(x => x.LeaveType).WithMany(x => x.LeaveAllocations).HasForeignKey(x => x.LeaveTypeId);
        }
    }
}