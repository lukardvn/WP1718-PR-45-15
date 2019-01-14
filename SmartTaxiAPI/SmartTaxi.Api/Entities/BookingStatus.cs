using System.Data.Entity;

namespace SmartTaxi.Api.Entities
{
    public enum BookingStatus
    {
        Kreirana,
        Otkazana,
        Formirana,
        Obradjena,
        Prihvacena,
        Neuspesna,
        Uspesna
    }
}