using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ApplicationLayer.ViewModels.LeaveTypes
{
    public class LeaveTypePagingRequest
    {
        public int PageSize { get; set; }
        public string? SearchValue { get; set; }
        public int StartPage { get; set; }
        public string SortColumn { get; set; }
        public string TypeSort { get; set; }

    }
}
