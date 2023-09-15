using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UFINETTest.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string isoCode { get; set; }
        public string Population { get; set; }
        public List<CountrySite> sites { get; set; }







    }
}
