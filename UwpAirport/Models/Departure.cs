using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpAirport.Models
{
    public class Departure
    {
        public int Id { get; set; }
        public Flight Flight { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public Crew Crew { get; set; }
        public Plane Plane { get; set; }
    }
}
