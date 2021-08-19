using Acerpro.Entities.Abstruct;

namespace Acerpro.Entities.Concreate.Entities
{
    public class CountryCurrency : Entity
    {
        public string CountryCode { get; set; }
        public string CountryIsoCode { get; set; }
        public string CountryName { get; set; }
        public string CapitalCityName { get; set; }
        public string CurrencyName { get; set; }
    }
}
