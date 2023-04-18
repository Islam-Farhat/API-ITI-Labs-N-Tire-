using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessDataController : ControllerBase
    {
        [HttpGet]
        [Route("Admin")]
        [Authorize(Policy = "JustAdmins")]
        public ActionResult DataforAdmin()
        {
            //var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //var user = await _userManager.FindByIdAsync(userId);

            /*
             *first  => this line equle two lines above
             *second => before we use it ,ClaimTypes.NameIdentifier must found we you register this user
            */
            // var user = await _userManager.GetUserAsync(User)


            return Ok("Hello Admin");
        }

        [HttpGet]
        [Route("AdminorUser")]
        [Authorize(Policy = "UsersorAdmins")]
        public ActionResult DataforAdminandUser()
        {
            return Ok("طلع البدر علينا");
        }
    }
}
