using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpAirport.Models
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlaneType PlaneType { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int Lifetime { get; set; }
    }
}
