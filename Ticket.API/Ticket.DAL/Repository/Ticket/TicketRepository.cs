using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ticket.DAL
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext context;

        public TicketRepository(TicketContext context)//inject 
        {
            this.context = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return context.Tickets.Include(x => x.Department).ToList();
        }

        public Ticket? GetById(int id)
        {
            return context.Tickets.Find(id);
        }
        
        public bool Add(Ticket entity)
        {
            try
            {
                context.Tickets.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool Update(Ticket entity)
        {
            try
            {
                context.Tickets.Update(entity);
                //SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        public bool Delete(Ticket entity)
        {
            try
            {
                context.Tickets.Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}
