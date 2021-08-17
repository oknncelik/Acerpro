using Acerpro.Shared.Extensions;
using Acerpro.Shared.Results.Abstruct;

namespace Acerpro.Shared.Results
{
    public class SuccessResult<TModel> : IResultModel<TModel>
    {
        public SuccessResult()
        {
        }

        public SuccessResult(TModel result, string message = "") : this(message)
        {
            Result = result;
        }

        public SuccessResult(string message)
        {
            if (message.IsNotEmpty())
                Message = message;
        }

        public string ResultType { get; } = "Success";
        public int Code { get; set; } = 0;
        public bool IsSuccess { get; } = true;
        public string Message { get; set; } = "Success";
        public TModel Result { get; set; }
    }
}
