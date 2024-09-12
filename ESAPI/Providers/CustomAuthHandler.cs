using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ESAPI.Providers
{
    public class CustomAuthHandler
    {
        public bool IsValidToken(string jwtToken, string issuer, string audience, string metadataAddress)
        {
            var openIdConnectConfig = AuthConfigManager.GetMetaData(metadataAddress);
            var signingKeys = openIdConnectConfig.SigningKeys;
            return ValidateToken(jwtToken, issuer, audience, signingKeys);
        }
        private bool ValidateToken(string jwtToken, string issuer, string audience, ICollection<SecurityKey> signingKeys)
        {
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1),
                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKeys = signingKeys,
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience
                };
                ISecurityTokenValidator tokenValidator = new JwtSecurityTokenHandler();
                var claim = tokenValidator.ValidateToken(jwtToken, validationParameters, out
                    var _);
                var scope = claim.FindFirst(c => c.Type.ToLower() == "<Here Scope Type>" && (c.Value.ToLower() == "<Here Scope>"));
                if (scope == null) throw new Exception("404 - Authorization failed - Invalid Scope");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("404 - Authorization failed", ex);
            }
        }


    }
}
