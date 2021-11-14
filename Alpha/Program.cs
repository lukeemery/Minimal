using Alpha;
using Alpha.Service;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiServices(builder.Configuration);
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
}

app.MapGet("/", (Func<string>)(() => "This a demo for JWT Authentication using Minimalist Web API"));


app.MapPost("/Login", async ([FromHeader(Name ="Authorization")] BasicCredentials credentials, IAuthService authService) =>
{
    var result = await authService.LoginAsync(credentials.UserName, credentials.Password);
    if (result.Succeeded)
        return Results.Ok(result.Token);

    return Results.BadRequest(result.Errors);
}).AllowAnonymous();


app.MapGet("/doaction", () => "Action Succeeded");

app.Run();