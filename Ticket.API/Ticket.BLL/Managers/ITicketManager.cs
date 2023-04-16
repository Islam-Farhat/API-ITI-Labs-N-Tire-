using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.BLL.Dtos.Tickets;
using Ticket.DAL;

namespace Ticket.BLL
{
    public interface ITicketManager
    {
        IEnumerable<TicketDto> GetAll();
        DAL.Ticket? GetById(int id);
        bool Add(AddTicketDto ticket);
        bool Update(UpdateAndDeleteDto entity);
        bool Delete(UpdateAndDeleteDto entity);
        //void SaveChanges();

    }
}
