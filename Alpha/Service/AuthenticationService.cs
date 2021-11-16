using Alpha.Store;
using Microsoft.AspNetCore.Identity;

namespace Alpha.Service;
public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenService _tokenService;
    private readonly IApplicationUserStore _applicationUserStore;

    public AuthenticationService(ITokenService tokenService, IApplicationUserStore applicationUserStore)
    {
        _tokenService = tokenService;
        _applicationUserStore = applicationUserStore;
    }

    public async Task<AuthenticationResult> LoginAsync(string userName, string password)
    {
        var user = await _applicationUserStore.FindByUsernameAsync(userName);
        if (user == null)
        {
            return new AuthenticationResult()
            {
                Errors = new List<string>() { "Invalid email or password" }
            };
        }

        var isValidPassword = user.Password == password;
        if (isValidPassword == true)
        {
            return new AuthenticationResult()
            {
                Succeeded = true,
                Token = _tokenService.GenerateToken(userName)
            };
        }

        return new AuthenticationResult()
        {
            Errors = new List<string>() { "Invalid email or password" }
        };
    }

    public async Task<AuthenticationResult> RegisterAsync(string userName, string password)
    {
        var user = new ApplicationUser()
        {
            Username = userName,
            Password = password
        };

        try
        {
            await _applicationUserStore.Create(user);
        }
        catch (Exception ex)
        {
            return new AuthenticationResult()
            {
                Errors = new[]
                {
                    ex.Message
                }
            };
        }

        return await this.LoginAsync(userName, password);
    }
}
