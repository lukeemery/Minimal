namespace Alpha.Model;

public record ApplicationUser()
{
    public string Password { get; internal set; }
    public string Username { get; internal set; }
}
