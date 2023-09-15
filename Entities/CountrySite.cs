using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UFINETTest.Entities
{
    public class CountrySite
    {
        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        [ForeignKey("Restaurant")]
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [ForeignKey("Hotel")]
        public int? HotelId { get; set; }
        public Hotel Hotel { get; set;}
    }
}
