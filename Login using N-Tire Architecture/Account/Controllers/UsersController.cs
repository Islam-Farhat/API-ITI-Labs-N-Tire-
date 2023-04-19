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
using static Account.BL.Dtos;

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
            bool result = await userManager.RegisterUser(register);

            //i want to show the errors
            if (result == false)
            {
                return BadRequest("Invalid Email or UserName!");
            }
            return Ok();
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<ActionResult> RegisterAdmin(RegisterDto register)
        {
            bool result = await userManager.RegisterAdmin(register);

            //i want to show the errors
            if (result == false)
            {
                return BadRequest("Invalid Email or UserName!");
            }
            return Ok();
        }

        [HttpPost]
        [Route("LoginAdminOrUser")]
        public async Task<ActionResult<TokenDto>> LoginAdminOrUser(LoginDto login)
        {
            var result = await userManager.Login(login);
            if (result.token == "erorr")
            {
                return Unauthorized("Wrong Username or password");
            }
            return Ok(result.token);
        }

    }
}
