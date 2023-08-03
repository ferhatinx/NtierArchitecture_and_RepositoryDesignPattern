using EFDersi.Data.Context;
using EFDersi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFDersi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            UdemyContext c = new();
            c.Products.Add(new() {  Name="Tv",Price=20000});
            c.Products.Add(new() { Name = "Tv-2"});

            c.SaveChanges();
            return View();
        }
    }
}
