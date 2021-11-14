namespace Alpha.Service;

public interface ITokenService
{
    string GenerateToken(string userName);
}