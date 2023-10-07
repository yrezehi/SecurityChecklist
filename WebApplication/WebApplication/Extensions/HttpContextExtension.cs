using Microsoft.AspNetCore.Http;
using System.Net;

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
                return GetForwarderForAddressIP(context);
            }

            return null;
        }

        private static string? GetForwarderForAddressIP(HttpContext context)
        {
            return context!.Request.Headers.TryGetValue("X-Forwarder-For", out var ips)
                    && IPAddress.TryParse(ips.FirstOrDefault()?.Split(',', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(), out IPAddress? clientIp)
                        ? (clientIp.ToString()) : null;
        }
    }
}
