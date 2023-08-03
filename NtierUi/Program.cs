using Microsoft.Extensions.FileProviders;
using NtierBusiness.Dependency;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependency();
builder.Services.AddControllersWithViews();


var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"node_modules")),
    RequestPath = "/node_modules"
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name:"pattern",
        pattern:"{Controller}/{Action}/{id?}",
        defaults: new { Controller="Home",Action="Index"}
       
        ); 
});
app.Run();
