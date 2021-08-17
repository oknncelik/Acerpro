using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Shared.Results.Abstruct;
using System.Threading.Tasks;

namespace Acerpro.Business.Abstruct
{
    public interface ICountryCurrencyService : IService<CountryCurrencyCreateDto, CountryCurrencyDto>
    {
        Task<IResult> GetCountryList();
    }
}
