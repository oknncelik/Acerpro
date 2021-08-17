using Acerpro.Data.Abstruct.Repositories;
using Acerpro.Data.Contexts;
using Acerpro.Entities.Concreate.Entities;

namespace Acerpro.Data.Concreate.Repositories
{
    public class CountryCurrencyRepository : Context<CountryCurrency, AcerproContext>, ICountryCurrencyRepository
    {

    }
}
