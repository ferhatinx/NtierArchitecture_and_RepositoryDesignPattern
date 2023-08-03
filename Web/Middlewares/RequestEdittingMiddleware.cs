namespace Web.Middlewares;

public class RequestEdittingMiddleware
{
    private RequestDelegate requestDelegate;

    public RequestEdittingMiddleware(RequestDelegate requestDelegate)
    {
        this.requestDelegate = requestDelegate;
    }
    public async Task Invoke(HttpContext httpContext)
    {
        if (httpContext.Request.Path.ToString() == "/ferhat")
            await httpContext.Response.WriteAsync("Hoşgeldin Ferhat");
        else
            await httpContext.Response.WriteAsync("Hoşgeldin köylü kemal");
       await this.requestDelegate.Invoke(httpContext);
        
    }
}
