using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartTaxi.Web.Domain.Enums;

namespace SmartTaxi.Web.Domain
{
    public class Vehicle
    {
        public long Id { get; set; }
        public string DriverId { get; set; }
        public int Year { get; set; }
        public string RegistrationNumber { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}