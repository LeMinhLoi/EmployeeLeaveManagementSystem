using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Common.Constants;
using Project.Data.Entities;

namespace Project.Data.SeedDataExtension
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminRoleId = new Guid("d381075c-8c50-4151-826f-1593b0a5cfad");
            var employeeRoleId = new Guid("cad321b2-437e-4edb-8e7b-8739071487af");
            modelBuilder.Entity<AppRole>().HasData(
                    new AppRole() { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN", Description = "Admin role", IsDefault = false, DateCreated = DateTime.Now.Date, DateModified = DateTime.Now.Date },
                    new AppRole() { Id = employeeRoleId, Name = "Employee", NormalizedName = "EMPLOYEE", Description = "Employee role", IsDefault = true, DateCreated = DateTime.Now.Date, DateModified = DateTime.Now.Date }
                );
            var hasher = new PasswordHasher<Employee>();
            var idFirstUser = new Guid("538c6ef9-62a4-4ea6-a8e3-3abb5bd86c3d");
            var idFirstAdmin = new Guid("6522df07-d852-46f1-9a67-732ab7efaf90");
            modelBuilder.Entity<Employee>().HasData(
                    new Employee() 
                    {
                        Id = idFirstAdmin, 
                        DateCreated = DateTime.Now.Date, 
                        DateModified = DateTime.Now.Date,
                        DateJoined = DateTime.Now.Date,
                        DateOfBirth = DateTime.Now.Date,
                        Gender = GenderType.Male,
                        PhotoUrl = null,
                        Lastname = "Minh Loi",
                        Firstname = "Le",
                        PhoneNumber = "0965920330",
                        PhoneNumberConfirmed = true,
                        Email = "loileminh@gmail.com",
                        EmailConfirmed = true,
                        UserName = "leminhloi1234",
                        NormalizedUserName = "leminhloi1234",
                        SecurityStamp = string.Empty,
                        PasswordHash = hasher.HashPassword(null, "Loi@1234")
                    },
                    new Employee()
                    {
                        Id = idFirstUser,
                        DateCreated = DateTime.Now.Date,
                        DateModified = DateTime.Now.Date,
                        DateJoined = DateTime.Now.Date,
                        DateOfBirth = DateTime.Now.Date,
                        Gender = GenderType.Male,
                        PhotoUrl = null,
                        Lastname = "Huynh",
                        Firstname = "Nhat",
                        PhoneNumber = "0965920123",
                        PhoneNumberConfirmed = true,
                        Email = "huynhnhat@gmail.com",
                        EmailConfirmed = true,
                        UserName = "huynhnhat1234",
                        NormalizedUserName = "huynhnhat1234",
                        SecurityStamp = string.Empty,
                        PasswordHash = hasher.HashPassword(null, "Nhat@1234")
                    }
                );
            var idFirstTypeLeave = new Guid("f55cae11-abeb-4cb5-ab7b-1d1d0de51452");
            var idSecondTypeLeave = new Guid("e703f007-be9c-43fe-8e84-c35f41354845");
            modelBuilder.Entity<LeaveType>().HasData(
                    new LeaveType() { Id = idFirstTypeLeave, Name = "For sick", DefaultDays = 17, DateCreated = DateTime.Now.Date, DateModified = DateTime.Now.Date},
                    new LeaveType() { Id = idSecondTypeLeave, Name = "For vacation", DefaultDays = 10, DateCreated = DateTime.Now.Date, DateModified = DateTime.Now.Date }
                );
        }
    } 
}
