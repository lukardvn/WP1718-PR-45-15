﻿namespace SmartTaxi.Web.Domain
{
    public class Address
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return $"{Street} {Number}, {City} {ZipCode}";
        }
    }
}