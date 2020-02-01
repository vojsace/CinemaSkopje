using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class BookTicket
    {
        public int BookTicketID { get; set; }
        public int MovieID { get; set; }
        public int HallID { get; set; }

        public Hall Hall { get; set; }
        public Movie Movie { get; set; }

    }
}
