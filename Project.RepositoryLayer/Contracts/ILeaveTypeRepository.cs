using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositoryLayer.Contracts
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType, Guid>
    {
    }
}
