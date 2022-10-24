using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ApplicationLayer.ViewModels.LeaveTypes
{
    public class LeaveTypeUpdateRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Days")]
        [Required]
        public int DefaultDays { get; set; }
    }
}
