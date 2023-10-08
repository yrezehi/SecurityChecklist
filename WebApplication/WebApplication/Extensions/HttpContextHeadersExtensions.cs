namespace Application.Extensions
{
    public static class HttpContextHeadersExtensions
    {
        public static void SetContentSecurityPolicy(this HttpContext context) =>
            context.Response.Headers.TryAdd("Content-Security-Policy", "default-src 'self'");

        public static void XSSProtection(this HttpContext context) =>
            context.Response.Headers.TryAdd("X-XSS-Protection", "1; mode=block");
    }
}
