using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartTaxi.Api.Entities;

namespace SmartTaxi.Api.Models
{
    public class AddBookingViewModel
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}