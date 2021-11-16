namespace Alpha.Model;

public record AuthenticationResult
{
    public bool Succeeded { get; init; }
    public string? Token { get; init; }
    public IEnumerable<string>? Errors { get; set; }
}