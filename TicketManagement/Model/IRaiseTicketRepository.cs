using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Model
{
    public interface IRaiseTicketRepository
    {
        
        List<RaiseTicket> GetAllTickets();
        RaiseTicket AddRaiseTicket(RaiseTicket raiseTicket);
        RaiseTicket EditTicket(int tno, RaiseTicket raiseTicket);
        RaiseTicket getTicketNumber(int TicketNo);
        List<RaiseTicket> GetTicketStatus(string status);
        void DeleteTicket(int TicketNo);

    }
}
