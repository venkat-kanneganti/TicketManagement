using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TicketManagement.Model
{
    public class RaiseTicketRepository : IRaiseTicketRepository
    {
        public string jsonfile = @"C:\Users\vk65806\source\repos\TicketManagement\TicketManagement\Data\data.json";

        private Dictionary<int, RaiseTicket> items;
        
        public RaiseTicket AddRaiseTicket(RaiseTicket raiseTicket)
        {
            using (StreamReader reader = new StreamReader(jsonfile))
            {
                string TicketList = reader.ReadToEnd();
                List<RaiseTicket> ListTicket = JsonConvert.DeserializeObject<List<RaiseTicket>>(TicketList);
                if (raiseTicket.TicketNo == 0)
                {
                    int key = items.Count;
                    while (items.ContainsKey(key))
                    {
                        key++;
                    }
                    raiseTicket.TicketNo = key;
                }
                
                ListTicket.Add(raiseTicket);
                string JsonTicketList = JsonConvert.SerializeObject(ListTicket, Formatting.Indented);
                reader.Close();
                File.WriteAllText(jsonfile, JsonTicketList);
                return raiseTicket;
            }
        }

        public RaiseTicket EditTicket(int tno, RaiseTicket raiseTicket)
        {
            using (StreamReader reader = new StreamReader(jsonfile))
            {
                string TicketList = reader.ReadToEnd();
                List<RaiseTicket> ListTicket = JsonConvert.DeserializeObject<List<RaiseTicket>>(TicketList);
                var ticket = ListTicket.Find(x => x.TicketNo == tno);
                if (ticket != null)
                {
                    ticket.Title = raiseTicket.Title;
                    ticket.status = raiseTicket.status;
                }
                string JsonTicketList = JsonConvert.SerializeObject(ListTicket, Formatting.Indented);
                reader.Close();
                File.WriteAllText(jsonfile, JsonTicketList);
                return ticket;

            }
        }

        public void DeleteTicket(int tno)
        {
            using (StreamReader reader = new StreamReader(jsonfile))
            {
                string TicketList = reader.ReadToEnd();
                List<RaiseTicket> ListTicket = JsonConvert.DeserializeObject<List<RaiseTicket>>(TicketList);
                RaiseTicket td = ListTicket.Find(y => y.TicketNo == tno);
                ListTicket.Remove(td);
                string JsonTicketList = JsonConvert.SerializeObject(ListTicket, Formatting.Indented);
                reader.Close();
                File.WriteAllText(jsonfile, JsonTicketList);
                
            }
        }

        public List<RaiseTicket> GetAllTickets()
        {
            using (StreamReader reader = new StreamReader(jsonfile))
            {
                
                string TicketList = reader.ReadToEnd();
                List<RaiseTicket> ListTicket = JsonConvert.DeserializeObject<List<RaiseTicket>>(TicketList);
                
                reader.Close();
                if (ListTicket != null)
                {
                    return ListTicket;
                }
                else
                {
                    return null;
                }
            }
        }
        public RaiseTicket getTicketNumber(int TicketNo)
        {
            using (StreamReader reader = new StreamReader(jsonfile))
            {
                string TicketList = reader.ReadToEnd();
                List<RaiseTicket> ListTicket = JsonConvert.DeserializeObject<List<RaiseTicket>>(TicketList);
                var ticket = ListTicket.Find(x => x.TicketNo == TicketNo);
                return ticket;
            }
        }

        public List<RaiseTicket> GetTicketStatus(string status)
        {
            using (StreamReader reader = new StreamReader(jsonfile))
            {
                string TicketList = reader.ReadToEnd();
                List<RaiseTicket> ListTicket = JsonConvert.DeserializeObject<List<RaiseTicket>>(TicketList);
                if (status == "pending")
                {
                    var fbs = (from fb in ListTicket
                               where fb.status == "pending"
                               select fb).ToList();
                    return fbs;

                }
                else
                {
                    var fbs = (from fb in ListTicket
                               where fb.status == "Approved"
                               select fb).ToList();
                    return fbs;
                }
                
            }
                
        }
    }
        //public IEnumerable<RaiseTicket> raiseTickets => items.Values;

        //public RaiseTicket this[int id] => items.ContainsKey(id) ? items[id] : null;

        //public RaiseTicket this[string status] => item.ContainsKey(status) ? item[status] : null;


    
}
