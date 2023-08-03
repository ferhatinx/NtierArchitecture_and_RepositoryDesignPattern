namespace Web.Middlewares
{
    public class ResponseEditingMiddleware 
    {
        private RequestDelegate _requestDelegate;

        public ResponseEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            await _requestDelegate.Invoke(context);
            if (context.Response.StatusCode == StatusCodes.Status200OK)
                await context.Response.WriteAsync("İşlem Başarılı");
            else
                await context.Response.WriteAsync("İşlem Başarısız");
        }
    }
}
