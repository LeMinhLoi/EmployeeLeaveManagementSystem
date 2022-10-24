using Project.Data.EF;
using Project.Data.Entities;
using Project.RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositoryLayer.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest, Guid>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
