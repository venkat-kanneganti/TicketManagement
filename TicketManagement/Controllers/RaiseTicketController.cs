using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TicketManagement.Model;


namespace TicketManagement.Controllers
{
    
    [ApiController]
    public class RaiseTicketController : ControllerBase
    {
        private IRaiseTicketRepository repository;


        //public RaiseTicketController(IRaiseTicketRepository repo)
        //{
        //    repository = repo;
        //}
        
        
        [Route("RaiseTicket/GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<RaiseTicket>> GetallTickets()
        {
           return repository.GetAllTickets();
        }

        [Route("RaiseTicket/GetId/{tno}")]
        [HttpGet]
        public ActionResult<RaiseTicket> GetTicket(int tno)
        {
            try
            {
                if (tno == 0)
                {
                    return BadRequest("Id has to be passed");
                }

                return repository.getTicketNumber(tno);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
            return Ok();
        }


        [Route("RaiseTicket/AddTicket")]
        [HttpPost]
        public RaiseTicket Post([FromBody] RaiseTicket rt) =>

            repository.AddRaiseTicket(new RaiseTicket
            {
                TicketNo = rt.TicketNo,
                UserName = rt.UserName,
                Title = rt.Title,
                status = rt.status,
                Date = rt.Date
            });


        [Route("RaiseTicket/UpdateTicket")]
        [HttpPut]
        public IActionResult EditTicket(int tno, [FromBody] RaiseTicket rts3)
        {
            if (tno == 0)
            {
                return BadRequest("Ticket Not Found");
            }
            else
            {
                repository.EditTicket(tno, rts3);
            }
            return Ok();
        }


        [Route("RaiseTicket/deleteticket/{tno}")]
        [HttpDelete]
        public IActionResult DeleteTicket(int tno)
        {
            if (tno == 0)
            {
                return BadRequest("Ticket Not Found");
            }
            else
            {
                repository.DeleteTicket(tno);
            }
            return Ok();
        }


        [Route("RaiseTicket/GetStatus/{sts}")]
        [HttpGet]
        public ActionResult<List<RaiseTicket>> GetTicketStatus(string sts)
        {
            if (sts == null)
            {
                return BadRequest("Id has to be passed");
            }
            else
            {
                return repository.GetTicketStatus(sts);
            }

        }
    }
}

        

 
    

