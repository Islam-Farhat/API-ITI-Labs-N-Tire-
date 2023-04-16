using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Ticket.BLL.Dtos.Tickets;
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
            IEnumerable<DAL.Ticket> TicketFromDb = ticketRepository.GetAll();
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
            return  ticketRepository.GetById(id);
            
        }
       
        public bool Add(AddTicketDto ticketDto)
        {
            var ticket = new DAL.Ticket();
            ticket.Title = ticketDto.Title;
            ticket.Description = ticketDto.Description;
            ticket.DepartmentId = ticketDto.DepartmentId;

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

        public bool Update(UpdateAndDeleteDto ticketDto)
        {
            var ticket = new DAL.Ticket();
            ticket.Id = ticketDto.Id;
            ticket.Title = ticketDto.Title;
            ticket.Description = ticketDto.Description;
            ticket.DepartmentId = ticketDto.DepartmentId;

            try
            {
                ticketRepository.Update(ticket);
                ticketRepository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
       
        public bool Delete(UpdateAndDeleteDto ticketDto)
        {
            var ticket = new DAL.Ticket();
            ticket.Id = ticketDto.Id;
            ticket.Title = ticketDto.Title;
            ticket.Description = ticketDto.Description;
            ticket.DepartmentId = ticketDto.DepartmentId;

            try
            {
                ticketRepository?.Delete(ticket);
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
