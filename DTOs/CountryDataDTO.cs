using UFINETTest.Entities;

namespace UFINETTest.DTOs
{
    public class CountryDataDTO
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string isoCode { get; set; }
        public string Population { get; set; }

        public List<Restaurant> Restaurants { get; set; }

        public List<Hotel> Hotels { get; set; }
    }
}
