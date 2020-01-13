using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Seat
    {
        public int SeatId { get; set; }
        public string SeatNo { get; set; }
        public string SeatTotal { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
