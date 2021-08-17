using Acerpro.Entities.Abstruct;
using Acerpro.Shared.Results.Abstruct;
using System.Threading.Tasks;

namespace Acerpro.Business.Abstruct
{
    public interface IService<TC, TU> 
        where TC : IDto
        where TU : IDto
    {

        Task<IResult> Get();
        Task<IResult> GetById(int id);
        Task<IResult> Save(TC createDto);
        Task<IResult> Update(TU updateDto);
    }
}
