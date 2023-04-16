using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ticket.BLL;
using Ticket.DAL;

namespace Ticket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketManager ticketManager;

        public TicketController(ITicketManager ticketManager)
        {
            this.ticketManager = ticketManager;
        }

        #region GetAll
        [HttpGet]
        public ActionResult<IEnumerable<TicketDto>> GetAll()
        {
            return Ok(ticketManager.GetAll().ToList());
        }
        #endregion
        
        #region GetById
        [HttpGet]
        [Route("GetById")]
        public ActionResult<DAL.Ticket?> GetById(int Id)
        {
            return ticketManager.GetById(Id);
        }
        #endregion

        #region Add
        [HttpPost]
        public ActionResult Add(DAL.Ticket entity)
        {
            bool result = ticketManager.Add(entity);
            if (result)
                return Ok();
            else
                return BadRequest();
        }
        #endregion

        #region Update
        [HttpPut]
        public ActionResult Update(DAL.Ticket entity)
        {
            bool result = ticketManager.Update(entity);
            if (result)
                return NoContent();
            else
                return BadRequest("ID not existed");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public ActionResult Delete(DAL.Ticket entity)
        {
            bool result = ticketManager.Delete(entity);
            if (result)
                return NoContent();
            else
                return BadRequest();
        }
        #endregion

    }
}
