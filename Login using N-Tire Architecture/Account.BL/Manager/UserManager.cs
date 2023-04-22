using Account.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Account.BL.Manager
{
    public class UserManager : IUserManager
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public UserManager(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        public async Task<RegisterResultDto> Register(RegisterDto register,string role)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = register.UserName,
                Email = register.Email,
                Address = register.Address,
                BirthDate = register.BirthDate,
            };
            var result = await userManager.CreateAsync(applicationUser, register.Password);
            if (!result.Succeeded)
            {
                List<IdentityError> errorList = result.Errors.ToList();
                var errors = string.Join(", ", errorList.Select(e => e.Description));

                return new RegisterResultDto(false, errors);
            }

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),//id created userManager.CreateAsync in this step
                    new Claim(ClaimTypes.Name,applicationUser.UserName),
                    new Claim(ClaimTypes.Email,applicationUser.Email),
                    new Claim(ClaimTypes.Role,role),
                };

            await userManager.AddClaimsAsync(applicationUser, claims);

            return new RegisterResultDto(true, null);
        }
        public async Task<LoginResultDto> Login(LoginDto login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                return new LoginResultDto(false,Errors:"Wrong UserName or Password",null);
            }
            var isauthenticated = await userManager.CheckPasswordAsync(user, login.Password);
            if (!isauthenticated)
            {
                return new LoginResultDto(false, Errors: "Wrong UserName or Password", null);
            }
            var claims = await userManager.GetClaimsAsync(user);

            #region SecretKey
            var secretkeystring = configuration.GetSection("SecretKey").Value!.ToString();
            var scretkeyinbyets = Encoding.ASCII.GetBytes(secretkeystring!);
            var secretkey = new SymmetricSecurityKey(scretkeyinbyets);
            #endregion

            #region Create combination between secretkey and algorithm

            var signcredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature);

            #endregion

            #region Putting all together

            var expireDate = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expireDate,
                signingCredentials: signcredentials);


            #endregion

            #region Convert token object to string

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenstring = tokenhandler.WriteToken(token);

            #endregion

            return new LoginResultDto(true, null, tokenstring);
        }
    }
}
