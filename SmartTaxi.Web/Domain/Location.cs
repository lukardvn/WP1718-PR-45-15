using System;

namespace SmartTaxi.Web.Domain
{
    public class Location
    {
        public long Id { get; set; }

        public string Latitude { get; set; }
        public string  Longitude { get; set; }

        public Address Address { get; set; }
    }
}