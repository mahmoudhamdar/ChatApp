using CharApp.Models;

namespace CharApp.Services;

public interface ITokenService
{
    public string CreateToken(User user);
}