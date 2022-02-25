using System.IdentityModel.Tokens.Jwt;
using jwtClient.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtTokenServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// app.MapGet("/", () => "Hello Client World!");

app.UseRouting();

// allows access to sub claim
//JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();