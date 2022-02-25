using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwtClient.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {

        var result = new ObjectResult(new
        {
            user = User.Identity?.Name ?? "NO NAME",
            isAuthenticated = User.Identity?.IsAuthenticated ?? false,
            authenticationType = User.Identity?.AuthenticationType ?? "NO AUTH",
            claims = User.Claims.Select(c => new
            {
                type = c.Type,
                issuer = c.Issuer,
                value = c.Value,
                valueType = c.ValueType
            }),
            roles = User.Claims.Where(c=>c.Type.Equals(ClaimTypes.Role)).Select(c=> c.Value),
            now = DateTime.Now.ToLongTimeString()
        });
        
        return await Task.FromResult(result);
    }
}