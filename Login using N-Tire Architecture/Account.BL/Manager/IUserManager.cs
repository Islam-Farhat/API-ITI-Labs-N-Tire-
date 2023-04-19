using static Account.BL.Dtos;


namespace Account.BL
{
    public interface IUserManager
    {
        Task<bool> RegisterUser(RegisterDto login);
        Task<bool> RegisterAdmin(RegisterDto login);
        Task<TokenDto> Login(LoginDto login);
    }
}
