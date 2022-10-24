using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositoryLayer.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaveAllocationRepository leaveAllocationRepository { get; }
        ILeaveRequestRepository leaveRequestRepository { get; }
        ILeaveTypeRepository leaveTypeRepository { get; }


        /// <summary>
        /// Call save change from db context
        /// </summary>
        int Commit();

        Task<int> CommitAsync();
    }
}
