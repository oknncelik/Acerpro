namespace Acerpro.Shared.Results.Abstruct
{
    public interface IResultModel<TModel> : IResult 
    {
        TModel Result { get; set; }
    }
}
