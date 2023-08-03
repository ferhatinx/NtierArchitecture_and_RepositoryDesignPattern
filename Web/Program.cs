using Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();



var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(configure =>
{
    configure.MapControllerRoute(
        name: "pattern",
        pattern:"{controller}/{action}/{id?}",
        defaults: new {Controller="Home",Action="Index"}
        );
});


app.Run();