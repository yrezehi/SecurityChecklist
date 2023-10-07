using Microsoft.AspNetCore.Http;
using System.Net;
using System.Security.Claims;

namespace Application.Extensions
{
    public static class HttpContextExtension
    {
        private static string FORWARDER_FOR_HEADER = "X-Forwarder-For";

        public static string? GetIP(this HttpContext context)
        {
            IPAddress? ipAddress = context.Connection.RemoteIpAddress;

            if(ipAddress != null)
            {
                return ipAddress.ToString();
            } else if (context.Request.Headers.ContainsKey(FORWARDER_FOR_HEADER))
            {
                return context.GetForwarderForAddressIP();
            }

            return null;
        }

        private static string? GetForwarderForAddressIP(this HttpContext context) =>
            context!.Request.Headers.TryGetValue("X-Forwarder-For", out var ips)
                    && IPAddress.TryParse(ips.FirstOrDefault()?.Split(',', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(), out IPAddress? clientIp)
                        ? (clientIp.ToString()) : null;

        public static string? GetCalimValue(this HttpContext context, string type) =>
            context.User.FindFirstValue(type);

        public static string? GetCookieValue(this HttpContext context, string key) =>
            context.Request.Cookies.FirstOrDefault(cookie => cookie.Key.Contains(key)).Value;
    }
}
