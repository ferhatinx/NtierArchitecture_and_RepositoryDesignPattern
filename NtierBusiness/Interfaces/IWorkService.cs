

using NtierCommon.ResponseObjects;
using NtierDtos.WorkDtos;

namespace NtierBusiness.Interfaces;

public interface IWorkService
{
    Task<IResponse<List<WorkListDto>>> WorkGetAll();

    Task<IResponse<WorkCreateDto>> WorkCreate(WorkCreateDto dto);

    Task<IResponse<IDto>> WorkGetByıd<IDto>(int id);

    Task<IResponse> WorkDelete(int id);

    Task<IResponse<WorkUpdateDto>> WorkUpdate(WorkUpdateDto dto);
}
