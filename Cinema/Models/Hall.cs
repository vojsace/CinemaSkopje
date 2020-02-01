using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public int NumSeats { get; set; }

        public ICollection<BookTicket> BookTickets { get; set; }
    }
}
