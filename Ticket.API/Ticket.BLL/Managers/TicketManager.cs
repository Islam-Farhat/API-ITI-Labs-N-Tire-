using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Ticket.DAL;

namespace Ticket.BLL
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicketRepository ticketRepository;

        public TicketManager(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }


        public IEnumerable<TicketDto> GetAll()
        {
            IEnumerable<Ticket.DAL.Ticket> TicketFromDb = ticketRepository.GetAll();
            return TicketFromDb.Select(x => new TicketDto
            {
                Id = x.Id,
                Description = x.Description,
                Title = x.Title,
                DepartmentName = x.Department?.Name
            });
        }

        public DAL.Ticket? GetById(int id)
        {
            return ticketRepository.GetById(id);
        }
       
        public bool Add(DAL.Ticket ticket)
        {
            
            try
            {
                ticketRepository.Add(ticket);
                ticketRepository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(DAL.Ticket entity)
        {
            try
            {
                ticketRepository.Update(entity);
                ticketRepository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        public bool Delete(DAL.Ticket entity)
        {
            
            try
            {
                ticketRepository?.Delete(entity);
                ticketRepository?.SaveChanges();
                return true;
            }
            catch
            {
                return true;
            }
        }

        //public void SaveChanges()
        //{
        //    ticketRepository.SaveChanges();
        //}
    }
}
