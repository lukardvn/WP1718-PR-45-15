﻿namespace SmartTaxi.Api.Entities
{
    public class Address
    {
        public long Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}