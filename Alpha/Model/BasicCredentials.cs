namespace Alpha.Model;

public record BasicCredentials([Required] string UserName, [Required][DataType(DataType.Password)] string Password)
{
    public static bool TryParse(string? value, IFormatProvider provider, out BasicCredentials? userViewModel)
    {
        if (!AuthenticationHeaderValue.TryParse(value, out var header))
        {
            userViewModel = default;
            return false;
        }

        if (string.IsNullOrWhiteSpace(header.Parameter))
        {
            userViewModel = default;
            return false;
        }

        var compositeString = Encoding.UTF8.GetString(Convert.FromBase64String(header.Parameter));
        var credentials = compositeString.Split(':', 2);

        if(credentials.Length != 2)
        {
            userViewModel = default;
            return false;
        }

        userViewModel = new BasicCredentials(credentials[0], credentials[1]);
        return true;
    }
}
