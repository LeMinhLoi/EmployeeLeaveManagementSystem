
using System.ComponentModel.DataAnnotations;

namespace Project.ApplicationLayer.ViewModels.LeaveTypes
{
    public class LeaveTypeCreateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Days")]
        public int DefaultDays { get; set; }
    }
}
