using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Ticket.DAL
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetById(int id);
        bool Add(Ticket entity);
        bool Update(Ticket entity);
        bool Delete(Ticket entity);
        void SaveChanges();
        
    }
}
