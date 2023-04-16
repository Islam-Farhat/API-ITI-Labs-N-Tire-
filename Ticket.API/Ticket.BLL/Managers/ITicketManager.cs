using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.DAL;

namespace Ticket.BLL
{
    public interface ITicketManager
    {
        IEnumerable<TicketDto> GetAll();
        DAL.Ticket? GetById(int id);
        bool Add(DAL.Ticket ticket);
        bool Update(DAL.Ticket entity);
        bool Delete(DAL.Ticket entity);
        //void SaveChanges();

    }
}
