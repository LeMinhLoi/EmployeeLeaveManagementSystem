using AutoMapper;
using Project.Data.Entities;
using Project.ApplicationLayer.ViewModels.LeaveTypes;

namespace Project.ApplicationLayer.AutoMapperExtension
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeListVM>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeCreateRequest>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeUpdateRequest>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetail>().ReverseMap();

        }
    }
}
