using Account.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Configuration;
using static Account.BL.Dtos;

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
        public async Task<bool> Register(RegisterDto register,string role)
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
                return false;
            }

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),//id created userManager.CreateAsync in this step
                    new Claim(ClaimTypes.Name,applicationUser.UserName),
                    new Claim(ClaimTypes.Email,applicationUser.Email),
                    new Claim(ClaimTypes.Role,role),
                };

            await userManager.AddClaimsAsync(applicationUser, claims);

            return true;
        }
        public async Task<TokenDto> Login(LoginDto login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                return new TokenDto("erorr");
            }
            var isauthenticated = await userManager.CheckPasswordAsync(user, login.Password);
            if (!isauthenticated)
            {
                return new TokenDto("erorr");
            }
            var claims = await userManager.GetClaimsAsync(user);

            #region SecretKey
            //var secretkeystring = configuration.GetValue<string>("SecretKey");
            var secretkeystring = "mykeyhgcgfdgfdfjdfujfyjd";
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

            return new TokenDto(tokenstring);
        }
    }
}
