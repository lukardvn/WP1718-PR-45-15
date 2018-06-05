using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartTaxi.Web.Models;

namespace SmartTaxi.Web.Domain
{
    public class Comment
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int Rate { get; set; }
    }
}