using jwtShared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace jwtServer.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly JwtOptions _options;

    public AuthenticationController(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    [HttpGet]
    public async Task<IActionResult> CreateToken()
    {
        var token = JwtHelpers.GenerateToken(_options);

        var result = new OkObjectResult(new { token });
        return await Task.FromResult<IActionResult>(result);
    }
}