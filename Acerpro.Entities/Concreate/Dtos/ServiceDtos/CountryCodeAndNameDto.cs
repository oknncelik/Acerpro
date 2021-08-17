using Acerpro.Entities.Abstruct;

namespace Acerpro.Entities.Concreate.Dtos.ServiceDtos
{
    public class CountryCodeAndNameDto : IDto
    {
        public string ISOCode { get; set; }

        public string Name { get; set; }
    }
}
