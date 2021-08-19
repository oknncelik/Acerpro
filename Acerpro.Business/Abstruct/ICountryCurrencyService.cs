using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Shared.Results.Abstruct;
using System.Threading.Tasks;

namespace Acerpro.Business.Abstruct
{
    public interface ICountryCurrencyService : IService<CountryCurrencyCreateDto, CountryCurrencyDto>
    {
        Task<IResult> GetCountryList();
        Task<IResult> CountryCurrency(string countryIsoCode);
        Task<IResult> CapitalCity(string countryIsoCode);
        Task<IResult> CountryIsoCode(string countryName);
        Task<IResult> GetCountryCurrencyList(string isoCode);
        Task<IResult> GetByIsoCode(string isoCode);
    }
}
