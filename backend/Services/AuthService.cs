using backend.DTOs;

namespace backend.Services;

public class AuthService : IAuthService
{
    private readonly IJwtTokenService _jwtTokenService;

    // In-memory user list for a simple reusable base app.
    private static readonly List<AppUser> Users = [];

    public AuthService(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    public AuthResponseDto Register(RegisterRequestDto request)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var userExists = Users.Any(x => x.Email == email);
        if (userExists)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "User already exists."
            };
        }

        var user = new AppUser
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        Users.Add(user);

        var token = _jwtTokenService.CreateToken(user, out var expiresAtUtc);

        return new AuthResponseDto
        {
            Success = true,
            Message = "Register successful.",
            Token = token,
            ExpiresAtUtc = expiresAtUtc,
            Email = user.Email
        };
    }

    public AuthResponseDto Login(LoginRequestDto request)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = Users.FirstOrDefault(x => x.Email == email);
        if (user is null)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        var passwordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
        if (!passwordValid)
        {
            return new AuthResponseDto
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        var token = _jwtTokenService.CreateToken(user, out var expiresAtUtc);

        return new AuthResponseDto
        {
            Success = true,
            Message = "Login successful.",
            Token = token,
            ExpiresAtUtc = expiresAtUtc,
            Email = user.Email
        };
    }
}
