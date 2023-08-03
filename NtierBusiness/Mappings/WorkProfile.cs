using AutoMapper;
using NtierDtos.WorkDtos;
using NtierEntities.Domains;


namespace NtierBusiness.Mappings;

public class WorkProfile : Profile
{
    public WorkProfile()
    {
        CreateMap<Work,WorkListDto>().ReverseMap();
        CreateMap<Work,WorkCreateDto>().ReverseMap();
        CreateMap<Work,WorkUpdateDto>().ReverseMap();
        CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
    }
}
