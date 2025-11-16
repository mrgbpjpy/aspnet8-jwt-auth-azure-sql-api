using Api.Models;

namespace Api.Services;

public interface ITokenService
{
    string CreateToken(User user);
}
