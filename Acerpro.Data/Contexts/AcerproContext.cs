using Acerpro.Entities.Concreate.Entities;
using System.Data.Entity;

namespace Acerpro.Data.Contexts
{
    public class AcerproContext : DbContext
    {
        public AcerproContext() : base(@"Server=localhost,1433; database=ExampleDB; User ID=sa; password=19Mayis1919!;")
        {

        }

        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
    }
}
