using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data.Entities;
using Project.Common.Constants;

namespace Project.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.Property(x => x.Firstname).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(200);
            builder.Property(x => x.DateJoined).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.PhotoUrl).IsRequired(false);
            builder.Property(x => x.Gender).HasDefaultValue(GenderType.Undefined);
        }
    }
}
