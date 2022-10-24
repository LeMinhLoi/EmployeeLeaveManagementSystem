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
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation, Guid>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
