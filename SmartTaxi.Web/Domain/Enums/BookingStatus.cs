using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartTaxi.Web.Domain.Enums
{
    public enum BookingStatus
    {
        Kreirana   = 0,
        Formirana  = 1,
        Obradjena  = 2,
        Prihvacena = 3,
        Otkazana   = 4,
        Neuspesna  = 5,
        Uspesna    = 6
    }
}