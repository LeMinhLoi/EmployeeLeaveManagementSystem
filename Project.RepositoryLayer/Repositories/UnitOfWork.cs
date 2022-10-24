using Project.Data.EF;
using Project.RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositoryLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ILeaveAllocationRepository leaveAllocationRepository { get; }
        public ILeaveRequestRepository leaveRequestRepository { get; }
        public ILeaveTypeRepository leaveTypeRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _context = context;
            this.leaveRequestRepository = leaveRequestRepository;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.leaveTypeRepository = leaveTypeRepository;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
