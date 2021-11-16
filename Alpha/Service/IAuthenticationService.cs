namespace Alpha.Service
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> LoginAsync(string userName, string password);
    }
}