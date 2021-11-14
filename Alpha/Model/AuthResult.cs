﻿namespace Alpha.Model;

public record AuthResult
{
    public bool Succeeded { get; set; }
    public string Token { get; set; }
    public IEnumerable<string> Errors { get; set; }
}