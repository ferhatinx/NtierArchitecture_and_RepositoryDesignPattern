using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Udemy.RepositoryDesignPattern.Data.Context;
using Udemy.RepositoryDesignPattern.Data.Interfaces;
using Udemy.RepositoryDesignPattern.Data.UnitOfWork;
using Udemy.RepositoryDesignPattern.Mappings;
using Udemy.RepositoryDesignPattern.Repositories;

var builder = WebApplication.CreateBuilder(args);
#region Context
builder.Services.AddDbContext<BankContext>(x =>
{
    x.UseSqlServer("server=DESKTOP-3KU2KP7; database=UdemyEFCoreBank; integrated security=true");
});
#endregion
#region Repository
builder.Services.AddScoped<IUow, Uow>();
//builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>)); 
//builder.Services.AddScoped<IAppUserRepository,AppUserRepository>();
//builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<IUserMapper,UserMapper>();
builder.Services.AddScoped<IAccountMapper,AccountMapper>();
#endregion
builder.Services.AddControllersWithViews();
var app = builder.Build();

if(app.Environment.IsDevelopment())
{ 
    app.UseDeveloperExceptionPage();
} 
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions { 
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")), 
    RequestPath= "/node_modules"
});
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name:"pattern",
        pattern:"{Controller}/{Action}/{id?}",
        defaults: new {Controller="Home",Action="Index"}
        
        );
});
app.Run();
