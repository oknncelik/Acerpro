using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Shared.Results.Abstruct;
using System.Threading.Tasks;

namespace Acerpro.Business.Abstruct.UiServices
{
    public interface ICountryCurrencyUiService
    {
        Task<IResult> GetCountryCurrencyList(string isoCode);
        Task<IResult> GetCountryList();
        Task<IResult> Save(CountryCurrencyCreateDto createDto);
    }
}
