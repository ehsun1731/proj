using System;
using System.Collections.Generic;

    public class Trip
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        public Trip(string origin, string destination, double price)
        {
            Origin = origin;
            Destination = destination;
            Price = price;
        }
    }

