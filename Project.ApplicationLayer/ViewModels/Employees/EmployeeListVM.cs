using Project.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ApplicationLayer.ViewModels.Employees
{
    public class EmployeeListVM
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public GenderType Gender{ get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhotoUrl { get; set; }
    }
}
