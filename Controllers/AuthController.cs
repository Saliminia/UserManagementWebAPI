using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TokenService _tokenService;

    public AuthController(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpGet("GenerateToken")]
    public IActionResult GenerateToken()
    {
        var token = _tokenService.GenerateToken();
        return Ok(token);
    }
}
