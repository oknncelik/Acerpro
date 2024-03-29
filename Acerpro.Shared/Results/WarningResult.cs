﻿using Acerpro.Shared.Results.Abstruct;

namespace Acerpro.Shared.Results
{
    public class WarningResult : IResult
    {
        public WarningResult(int code, string message) : this(message)
        {
            Code = code;
        }

        public WarningResult(string message)
        {
            Message = message;
        }

        public string ResultType { get; } = "Warning";
        public int Code { get; set; }
        public bool IsSuccess { get; } = false;
        public string Message { get; set; }
    }
}
