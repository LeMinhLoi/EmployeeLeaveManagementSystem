using Project.ApplicationLayer.ViewModels.LeaveTypes;
using Project.Data.Entities;

namespace Project.ApplicationLayer.Contracts
{
    public interface ILeaveTypeService
    {
        Task<LeaveType> GetAsync(Guid id);

        Task<List<LeaveTypeListVM>> GetAllAsync();

        Task<LeaveTypePageResult> GetPagingAsync(LeaveTypePagingRequest leaveTypePagingRequest);

        Task<LeaveType> AddAsync(LeaveType entity);

        Task UpdateAsync(LeaveType entity);

        Task DeleteAsync(Guid id);
    }
}