using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using System.Collections.Generic;

namespace Acerpro.Integrations.Abstruct
{
    public interface ICountryInfoIntegration
    {
        string CapitalCity(string countryISOCode);
        CurrencyDto CountryCurrency(string countryISOCode);
        string CountryISOCode(string countryName);
        IList<CountryCodeAndNameDto> ListOfCountryNamesByCode();
    }
}
