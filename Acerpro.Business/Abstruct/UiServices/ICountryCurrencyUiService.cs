using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Shared.Results.Abstruct;

namespace Acerpro.Business.Abstruct.UiServices
{
    public interface ICountryCurrencyUiService
    {
        IResult GetCountryCurrencyList(string isoCode);
        IResult GetCountryList();
        IResult Save(CountryCurrencyCreateDto createDto);
    }
}
