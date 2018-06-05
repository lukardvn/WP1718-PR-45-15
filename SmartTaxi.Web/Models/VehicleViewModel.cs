using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SmartTaxi.Web.Domain.Enums;

namespace SmartTaxi.Web.Models
{
    public class VehicleViewModel
    {
        public long Id { get; set; }

        public VehicleType VehicleType { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public int Year { get; set; }

    }
}