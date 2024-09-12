using ESAPI.IRepositories;

namespace ESAPI.Providers
{
    public class AuthMiddleware: IAuthMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        public AuthMiddleware(IConfiguration appConfigurationr, RequestDelegate _next)
        {
            configuration = appConfigurationr;
            next = _next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var path = httpContext.Request.Path;
                string token = string.Empty;
                string issuer = configuration["JwtToken:Issuer"]; //Get issuer value from your configuration
                string audience = configuration["JwtToken:Audience"]; //Get audience value from your configuration
                string metaDataAddress = issuer + "/.well-known/oauth-authorization-server";
                CustomAuthHandler authHandler = new CustomAuthHandler();
                var header = httpContext.Request.Headers["Authorization"];
                if (header.Count == 0) throw new Exception("Authorization header is empty");
                string[] tokenValue = Convert.ToString(header).Trim().Split(" ");
                if (tokenValue.Length > 1) token = tokenValue[1];
                else throw new Exception("Authorization token is empty");
                if (authHandler.IsValidToken(token, issuer, audience, metaDataAddress)) await next(httpContext);
            }
            catch (Exception)
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                HttpResponseWritingExtensions.WriteAsync(httpContext.Response, "{\"message\": \"Unauthorized\"}").Wait();
            }
        }
    }
}
