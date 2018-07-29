using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpAirport.Models
{
    public class PlaneType
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int NumberOfSeats { get; set; }
        public int CarryingCapacity { get; set; }
        public int MaxRange { get; set; }
        public int MaxSpeed { get; set; }
        public int MaxAltitude { get; set; }
    }
}
