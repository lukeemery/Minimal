var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDocumentation();
builder.Services.AddConfig(builder.Configuration);
builder.Services.AddEndpointSecurity(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.UseSwagger();
// app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

SecurityEndpoints.Map(app);
CoreEndpoints.Map(app);

app.Run();