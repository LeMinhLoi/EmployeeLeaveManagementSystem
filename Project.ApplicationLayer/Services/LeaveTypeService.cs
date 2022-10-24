using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.ApplicationLayer.Contracts;
using Project.ApplicationLayer.ViewModels.LeaveTypes;
using Project.Data.Entities;
using Project.RepositoryLayer.Contracts;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Project.ApplicationLayer.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public LeaveTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<LeaveType> AddAsync(LeaveType entity)
        {
            await unitOfWork.leaveTypeRepository.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await unitOfWork.leaveTypeRepository.DeleteAsync(id);
        }

        public async Task<List<LeaveTypeListVM>> GetAllAsync()
        {
            return mapper.Map<List<LeaveTypeListVM>>(await unitOfWork.leaveTypeRepository.GetAllAsync());
        }

        public Task<LeaveType> GetAsync(Guid id)
        {
            return unitOfWork.leaveTypeRepository.GetAsync(id);
        }

        public async Task<LeaveTypePageResult> GetPagingAsync(LeaveTypePagingRequest request)
        {
            var data = await GetAllAsync();
            if(data == null)
            {
                return new LeaveTypePageResult()
                {
                    RecordsTotal = 0,
                    RecordsFiltered = 0,
                    LeaveTypeListVMs = null
                };
            }
            var totalRecord = data.Count();
            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                data = data.Where(x => x.Name.ToLower().Contains(request.SearchValue.ToLower()) || x.DefaultDays.ToString().Contains(request.SearchValue.ToLower())).ToList();
            }
            var filterRecord = data.Count();
            data = data.Skip((request.StartPage - 1) * request.PageSize).Take(request.PageSize).ToList();
            if (request.SortColumn == "Name")
            {
                if (request.TypeSort.Equals("asc") )
                {
                    data.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    data.OrderByDescending(x => x.Name).ToList();
                }
            }
            else
            {
                if (request.TypeSort.Equals("asc"))
                {
                    data.OrderBy(x => x.DefaultDays).ToList();
                }
                else
                {
                    data.OrderByDescending(x => x.DefaultDays).ToList();
                }
            }
            //sort data
            //if(!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.TypeSort))
            //{
            //    data = data.OrderBy(request.SortColumn + " " + request.TypeSort);
            //}
            return new LeaveTypePageResult()
            {
                RecordsTotal = totalRecord,
                RecordsFiltered = filterRecord,
                LeaveTypeListVMs = data
            };
        }

        public async Task UpdateAsync(LeaveType entity)
        {
            await unitOfWork.leaveTypeRepository.UpdateAsync(entity);
        }
    }
}
