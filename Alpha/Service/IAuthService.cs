using Alpha.Model;

namespace Alpha.Service
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(string userName, string password);
    }
}