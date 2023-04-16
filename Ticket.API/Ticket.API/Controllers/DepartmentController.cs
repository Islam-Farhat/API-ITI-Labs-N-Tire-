using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket.BLL;
using Ticket.DAL;

namespace Ticket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentManager departmentManager;

        public DepartmentController(IDepartmentManager departmentManager)
        {
            this.departmentManager = departmentManager;
        }

        #region DepartmentDetail

        [HttpGet]
        [Route("DepartmentDetail")]
        public ActionResult<DepartmentDetailsDto> DepartmentDetail(int id)
        {
            var department = departmentManager.GetDetails(id);
            if (department is null)
            {
                return BadRequest();
            }
            return Ok(department);
        }
        #endregion
    }
}
