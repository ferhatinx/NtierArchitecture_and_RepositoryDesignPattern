

using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NtierBusiness.Interfaces;
using NtierBusiness.Mappings;
using NtierBusiness.Services;
using NtierBusiness.ValidationRules;
using NtierDataAccess.Context;
using NtierDataAccess.Uow;
using NtierDtos.WorkDtos;
using NtierEntities.Domains;
using System;

namespace NtierBusiness.Dependency;

public static class DependencyExtension
{
    public static void AddDependency(this IServiceCollection services)
    {
        services.AddDbContext<TodoContext>(opt =>
        {
            opt.UseSqlServer("server=DESKTOP-3KU2KP7; database=NtierUdemy; integrated security=true");
        });
        #region AutoMapper
        var mapperConfiguration = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new WorkProfile());
        });
        var mapper = mapperConfiguration.CreateMapper();

        services.AddSingleton<IMapper>(mapper);
        #endregion
        #region FluentValidation
        services.AddTransient<IValidator<WorkCreateDto>, WorkCreateDtoValidator>();
        services.AddTransient<IValidator<WorkUpdateDto>, WorkUpdateDtoValidator>();
        #endregion

        services.AddScoped<IUow,Uow>();
        services.AddScoped<IWorkService, WorkService>();
    }
}
