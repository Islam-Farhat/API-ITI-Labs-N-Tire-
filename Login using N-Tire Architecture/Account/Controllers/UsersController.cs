using Account.BL;
using Account.Data.Models;
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
        private readonly IUserManager userManager;

        public UsersController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegitserUser(RegisterDto register)
        {
            var result = await userManager.Register(register,"User");

            if (result.IsSuccesfull == false)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin(RegisterDto register)
        {
            var result = await userManager.Register(register, "Admin");

            if (result.IsSuccesfull == false)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [HttpPost]
        [Route("LoginAdminOrUser")]
        public async Task<ActionResult<LoginResultDto>> LoginAdminOrUser(LoginDto login)
        {
            var result = await userManager.Login(login);
            if (!result.IsSuccesfull)
            {
                return Unauthorized(result.Errors);
            }
            return Ok(result.Token);
        }

    }
}
