using Acerpro.Entities.Abstruct;

namespace Acerpro.Entities.Concreate.Dtos
{
    public class CountryCurrencyDto : IDto
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryIsoCode { get; set; }
        public string CountryName { get; set; }
        public string CapitalCityName { get; set; }
        public string CurrencyName { get; set; }
        public bool ActiveFlag { get; set; }
    }
}
