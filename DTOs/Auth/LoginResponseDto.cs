namespace TimeTrack.API.DTOs.Auth;

public class LoginResponseDto
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string Department { get; set; }
    public string Token { get; set; }
    public DateTime TokenExpiration { get; set; }
}