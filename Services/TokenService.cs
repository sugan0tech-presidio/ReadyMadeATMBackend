using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReadyMadeATMBackend.Models;

namespace ReadyMadeATMBackend.Services;

public class TokenService : ITokenService
{
    private readonly SymmetricSecurityKey _key;

    /// <intheritdoc/>
    public TokenService(IConfiguration configuration)
    {
        var secretKey = "This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing";
        if (secretKey == null)
            throw new AuthenticationException("No Token generation Secret key found for this Environment");
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    }

    /// <intheritdoc/>
    public string GenerateToken(User user, DateTime expiration)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Id.ToString()),
            new(ClaimTypes.SerialNumber, user.AtmNumber)
        };
        var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
        var myToken = new JwtSecurityToken(null, null, claims, expires: expiration,
            signingCredentials: credentials);
        var token = new JwtSecurityTokenHandler().WriteToken(myToken);
        return token;
    }

    /// <intheritdoc/>
    public TokenPayloadDto GetPayload(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = _key,
            ValidateIssuer = false,
            ValidateAudience = false
        };
        tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
        var jwtToken = (JwtSecurityToken)validatedToken;
        var claims = jwtToken.Claims;
        var enumerable = claims as Claim[] ?? claims.ToArray();
        var payload = new TokenPayloadDto
        {
            UserId = int.Parse(enumerable.First(x => x.Type == ClaimTypes.Name).Value),
            AtmNo = enumerable.First(x => x.Type == ClaimTypes.SerialNumber).Value
        };

        return payload;
    }
}