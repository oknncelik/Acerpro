using Acerpro.Entities.Abstruct;

namespace Acerpro.Entities.Concreate.Dtos.ServiceDtos
{
    public class CurrencyDto : IDto
    {
        public string ISOCode { get; set; }

        public string Name { get; set; }
    }
}
