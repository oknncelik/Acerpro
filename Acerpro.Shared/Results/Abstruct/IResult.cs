namespace Acerpro.Shared.Results.Abstruct
{
    public interface IResult
    {
        string ResultType { get; }
        int Code { get; set; }
        bool IsSuccess { get; }
        string Message { get; set; }
    }
}
