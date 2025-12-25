using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EMS.Domain.Constants;
using EMS.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EMS.Domain.Common;

public class JwtHelpers
{
    private static readonly string _key = Env.GetJwtKey();

    public static string GenerateToken(
        JwtModel request,
        string? key = null,
        int expireTimeInHour = AppJwtConstants.ExpireTimeInHour
    )
    {
        key ??= _key;

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(key);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, request.Id.ToString()),
            new(ClaimTypes.Email, request.Email),
            new(ClaimTypes.Name, request.Ten),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(expireTimeInHour), // Expires time
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static void ConfigureJwtBearer(JwtBearerOptions opt, string key)
    {
        opt.TokenValidationParameters = GenerateTokenValidationParameters(key);

        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
                {
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            }
        };
    }

    public static ClaimsPrincipal? GetPrincipalFromToken(string token, string key)
    {
        var tokenValidationParameters = GenerateTokenValidationParameters(key);

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;
        }
        catch
        {
            return null;
        }
    }

    public static string? GetClaimValueFromToken(string token, string claimType)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        if (!tokenHandler.CanReadToken(token))
        {
            return null;
        }

        var jwtToken = tokenHandler.ReadJwtToken(token);
        return jwtToken.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;
    }

    private static TokenValidationParameters GenerateTokenValidationParameters(string key)
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
        };
    }
}
