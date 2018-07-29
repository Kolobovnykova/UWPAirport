using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpAirport.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string PointOfDeparture { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public string Destination { get; set; }
        public DateTime DateOfArrival { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
