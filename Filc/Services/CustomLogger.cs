using NuGet.Common;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Filc.Services
{
    public static class CustomLogger
    {
        public static void LogRequest(string token, string message)
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken decodedValue = handler.ReadJwtToken(token);
            string user = decodedValue.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            string role = decodedValue.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            Log.Information($"User: {user} Role: {role} Request: {message}");
        }

        public static void LogError(string stackTrace, string message)
        {
            Log.Error($"Error: {message} \n StackTrace: {stackTrace}");
        }
    }
}
