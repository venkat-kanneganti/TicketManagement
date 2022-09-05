using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Model
{
    public class RaiseTicket
    {
        public int TicketNo { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string status { get; set; }
        public DateTime Date { get; set; }
    }
}
