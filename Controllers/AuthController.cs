using Microsoft.AspNetCore.Mvc;
using TimeTrack.API.DTOs.Auth;
using TimeTrack.API.DTOs.Common;
using TimeTrack.API.Models.Enums;
using TimeTrack.API.Service;

namespace TimeTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// User login endpoint
    /// </summary>
    [HttpPost("login")]
    public async Task<ActionResult<ApiResponseDto<LoginResponseDto>>> Login([FromBody] LoginRequestDto request)
    {
        var result = await _authService.LoginAsync(request);
        return Ok(ApiResponseDto<LoginResponseDto>.SuccessResponse(result, "Login successful"));
    }

    /// <summary>
    /// User registration endpoint
    /// </summary>
    [HttpPost("register")]
    public async Task<ActionResult<ApiResponseDto<LoginResponseDto>>> Register([FromBody] RegisterRequestDto request)
    {
        var result = await _authService.RegisterAsync(request);
        return Ok(ApiResponseDto<LoginResponseDto>.SuccessResponse(result, "Registration successful"));
    }

    /// <summary>
    /// Get available departments for registration dropdown
    /// </summary>
    [HttpGet("departments")]
    public ActionResult<ApiResponseDto<IEnumerable<string>>> GetDepartments()
    {
        return Ok(ApiResponseDto<IEnumerable<string>>.SuccessResponse(
            DepartmentType.AllDepartments, 
            "Available departments retrieved"));
    }

    /// <summary>
    /// Get available roles for registration dropdown
    /// </summary>
    [HttpGet("roles")]
    public ActionResult<ApiResponseDto<IEnumerable<string>>> GetRoles()
    {
        var roles = new[] { "Employee", "Manager", "Admin" };
        return Ok(ApiResponseDto<IEnumerable<string>>.SuccessResponse(
            roles, 
            "Available roles retrieved"));
    }
}