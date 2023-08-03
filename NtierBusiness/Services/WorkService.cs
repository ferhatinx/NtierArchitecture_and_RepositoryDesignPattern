

using AutoMapper;
using FluentValidation;
using NtierBusiness.Extensions;
using NtierBusiness.Interfaces;
using NtierCommon.ResponseObjects;
using NtierDataAccess.Interfaces;
using NtierDataAccess.Uow;
using NtierDtos.WorkDtos;
using NtierEntities.Domains;

namespace NtierBusiness.Services;

public class WorkService : IWorkService
{
    private readonly IUow _uow;
    private readonly IRepository<Work> _workRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<WorkCreateDto> _createDtoValidator;
    private readonly IValidator<WorkUpdateDto> _updateDtoValidator;
    public WorkService(IUow uow, IMapper mapper, IValidator<WorkCreateDto> createDtoValidator, IValidator<WorkUpdateDto> updateDtoValidator)
    {
        _uow = uow;
        _workRepository = _uow.GetRepository<Work>();
        _mapper = mapper;
        _createDtoValidator = createDtoValidator;
        _updateDtoValidator = updateDtoValidator;
    }

    public async Task<IResponse<WorkUpdateDto>> WorkUpdate(WorkUpdateDto dto)
    {
        var validateResult = _updateDtoValidator.Validate(dto);
        if (validateResult.IsValid)
        {

            var updatedEntity = await _workRepository.GetByIdAsync(dto.Id);
            if (updatedEntity != null)
            {
                await _workRepository.Update(_mapper.Map<Work>(dto), updatedEntity);
                await _uow.SaveChangesAsync();
                return new Response<WorkUpdateDto>(ResponseType.Success, dto);
            }
            return new Response<WorkUpdateDto>(ResponseType.NotFound,dto);
        }
        var customValidationErrors = ValidationResultExtemsion.ConvertToValidationResult(validateResult);
        return new Response<WorkUpdateDto>(ResponseType.ValidationError,dto,customValidationErrors);
    }

    public async Task<IResponse<WorkCreateDto>> WorkCreate(WorkCreateDto dto)
    {
        var validationResult = _createDtoValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            await _workRepository.CreateAsync(_mapper.Map<Work>(dto));
            await _uow.SaveChangesAsync();
            return new Response<WorkCreateDto>(ResponseType.Success,dto);
        }
        var customValidationErrors = ValidationResultExtemsion.ConvertToValidationResult(validationResult);
        return new Response<WorkCreateDto>(ResponseType.ValidationError,dto,customValidationErrors);
        

    }

    public async Task<IResponse> WorkDelete(int id)
    {
        var deletedEntity = await _workRepository.GetByFilterAsync(filter => filter.Id == id);
        if (deletedEntity != null)
        {
            _workRepository.Delete(deletedEntity);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }
        return new Response(ResponseType.NotFound);

    }

    public async Task<IResponse<List<WorkListDto>>> WorkGetAll()
    {
        var workList = await _workRepository.GetAllAsync();
        var mappedworklistdto = _mapper.Map<List<WorkListDto>>(workList);
        return new Response<List<WorkListDto>>(ResponseType.Success, mappedworklistdto);
    }

    public async Task<IResponse<IDto>> WorkGetByıd<IDto>(int id)
    {
        var work = _mapper.Map<IDto>(await _workRepository.GetByFilterAsync(x => x.Id == id));
        if(work != null)
        {
            return new Response<IDto>(ResponseType.Success,work);
        }
        else
        {
            return new Response<IDto>(ResponseType.NotFound);
        }
    
        

    }
}
