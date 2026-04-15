using backend.DTOs;

namespace backend.Services;

public interface IAuthService
{
    AuthResponseDto Register(RegisterRequestDto request);
    AuthResponseDto Login(LoginRequestDto request);
}
