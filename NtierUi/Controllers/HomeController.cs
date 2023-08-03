using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using NtierBusiness.Interfaces;
using NtierDtos.WorkDtos;
using NtierUi.Extensions;

namespace NtierUi.Controllers;
public class HomeController : Controller
{
    private readonly IWorkService _workService;
    

    public HomeController(IWorkService workService)
    {
        _workService = workService;
     
    }

    public async Task<IActionResult> Index()
    {
        var response =  await _workService.WorkGetAll();
        return this.ResponseView(response);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(WorkCreateDto createDto)
    {
        
        var response = await _workService.WorkCreate(createDto);
        return this.ResponseRedirectToAction<WorkCreateDto>(response, "Index", "Home");
       
    }
    public async Task<IActionResult> Update(int id) 
    {
       
        var response = await _workService.WorkGetByıd<WorkUpdateDto>(id);
        return this.ResponseView(response); 
    }
    [HttpPost]
    public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
    {
      
        
           var response =  await _workService.WorkUpdate(workUpdateDto);
        return this.ResponseRedirectToAction(response, "Index", "Home");
        
    }
    
    public async Task<IActionResult> Remove(int id)
    {
        var response =  await _workService.WorkDelete(id);
        return this.ResponseRedirectToAction(response, "Index", "Home");
    }
    public IActionResult NotFound()
    {
        return View();
    }
}
