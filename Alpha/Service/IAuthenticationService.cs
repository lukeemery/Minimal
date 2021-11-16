namespace Alpha.Service
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> LoginAsync(string userName, string password);
        Task<AuthenticationResult> RegisterAsync(string userName, string password);
    }
}