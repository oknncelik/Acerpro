using Acerpro.Entities.Concreate.Entities;
using System.Data.Entity;

namespace Acerpro.Data.Contexts
{
    public class AcerproContext : DbContext
    {
        public AcerproContext() : base("AppDb")
        {

        }

        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
    }
}
