using System.Net.Http.Headers;

public record BasicCredentials([Required] string UserName, [Required][DataType(DataType.Password)] string Password)
{
    public static bool TryParse(string? value, IFormatProvider provider, out BasicCredentials? userViewModel)
    {
        if(AuthenticationHeaderValue.TryParse(value, out var header))
        {
            var compositeString = Encoding.UTF8.GetString(Convert.FromBase64String(header.Parameter));
            var credentials = compositeString.Split(':', 2);
            userViewModel = new BasicCredentials(credentials[0], credentials[1]);
            return true;
        }
        userViewModel = default;
        return false;
    }
}
