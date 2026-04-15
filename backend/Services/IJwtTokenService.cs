namespace backend.Services;

public interface IJwtTokenService
{
    string CreateToken(AppUser user, out DateTime expiresAtUtc);
}
