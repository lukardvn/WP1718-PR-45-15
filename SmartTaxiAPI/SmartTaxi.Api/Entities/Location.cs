using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTaxi.Api.Entities
{
    public class Location
    {
        public long Id { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}