namespace Application.Events
{
    public class RateLimitEventHandler : IMiddleware
    {
        public RateLimitEventHandler() { }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
        }
    }
}
