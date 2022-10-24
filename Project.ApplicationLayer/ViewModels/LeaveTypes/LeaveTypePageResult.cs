using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ApplicationLayer.ViewModels.LeaveTypes
{
    public class LeaveTypePageResult
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<LeaveTypeListVM> LeaveTypeListVMs { get; set; }
    }
}
