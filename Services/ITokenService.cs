using ReadyMadeATMBackend.Models;

namespace ReadyMadeATMBackend.Services;

public interface ITokenService
{
    /// <summary>
    ///  Generates JWT token with given user & expiration
    /// </summary>
    /// <param name="user"></param>
    /// <param name="expiration"></param>
    /// <returns></returns>
    public string GenerateToken(User user, DateTime expiration);

    /// <summary>
    /// Extracts and returns payload of a token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public TokenPayloadDto GetPayload(string token);
}