using Account.Data.Models;
using Account.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(IConfiguration configuration,UserManager<ApplicationUser> userManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
        }
        #region Login
        [HttpPost]
        [Route("Login")]
        public ActionResult<TokenDto> Login(LoginDto login)
        {
            var claims = new List<Claim>()
            {
                new Claim("Name","Loma"),
                new Claim("Name","Loma"),
                new Claim("Name","Loma"),
            };
            #region SecretKey
            var secretkeystring = configuration.GetValue<string>("SecretKey");
            var scretkeyinbyets = Encoding.ASCII.GetBytes(secretkeystring!);
            var secretkey = new SymmetricSecurityKey(scretkeyinbyets);
            #endregion

            #region Create combination between secretkey and algorithm

            var signcredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature);

            #endregion

            #region Putting all together

            var expireDate = DateTime.Now.AddDays(1);
            var token = new JwtSecurityToken(
                claims: claims
                , expires: expireDate
                , signingCredentials: signcredentials);


            #endregion

            #region Convert token object to string

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenstring = tokenhandler.WriteToken(token);

            #endregion

            return new TokenDto(tokenstring);
        }
        #endregion

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin(RegisterDto register)
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
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),//id created userManager.CreateAsync in this step
                new Claim(ClaimTypes.Name,applicationUser.UserName),
                new Claim(ClaimTypes.Email,applicationUser.Email),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            await userManager.AddClaimsAsync(applicationUser, claims);
            return Ok();
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegitserUser(RegisterDto register)
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
                return BadRequest(result.Errors);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),//id created userManager.CreateAsync in this step
                new Claim(ClaimTypes.Name,applicationUser.UserName),
                new Claim(ClaimTypes.Email,applicationUser.Email),
                new Claim(ClaimTypes.Role,"User"),
            };

            await userManager.AddClaimsAsync(applicationUser, claims);
            return Ok();
        }

        [HttpPost]
        [Route("LoginAdminOrUser")]
        public async Task<ActionResult<TokenDto>> LoginAdminOrUser(LoginDto login)
        {
            var user = await userManager.FindByNameAsync(login.UserName);
            if (user == null) 
            {
                return BadRequest();
            }
            var isauthenticated= await userManager.CheckPasswordAsync(user, login.Password);
            if (!isauthenticated)
            {
                return BadRequest();
            }
            var claims =await userManager.GetClaimsAsync(user);

            #region SecretKey
            var secretkeystring = configuration.GetValue<string>("SecretKey");
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
