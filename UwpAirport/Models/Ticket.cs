﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpAirport.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public decimal Price { get; set; }
    }
}
