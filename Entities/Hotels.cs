using System.ComponentModel.DataAnnotations.Schema;

namespace UFINETTest.Entities
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set;}
        public string Stars { get; set; }
    }
}
