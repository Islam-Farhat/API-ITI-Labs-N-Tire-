
namespace Account.BL
{
    public interface IUserManager
    {
        Task<RegisterResultDto> Register(RegisterDto login,string role);
        Task<LoginResultDto> Login(LoginDto login);
    }
}
