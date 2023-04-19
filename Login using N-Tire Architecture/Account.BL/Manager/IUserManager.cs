using static Account.BL.Dtos;


namespace Account.BL
{
    public interface IUserManager
    {
        //Task<bool> RegisterUser(RegisterDto login);
        //Task<bool> RegisterAdmin(RegisterDto login);
        Task<bool> Register(RegisterDto login,string role);
        Task<TokenDto> Login(LoginDto login);
    }
}
