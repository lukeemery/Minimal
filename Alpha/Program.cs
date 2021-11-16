var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDocumentation();
builder.Services.AddConfig(builder.Configuration);
builder.Services.AddEndpointSecurity(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

LoginEndpoints.Map(app);
CoreEndpoints.Map(app);

app.Run();