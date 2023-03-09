using System;

#nullable enable

namespace StateSmith.Output;

public class TranspilerException : Exception
{
    public string? GilCode { get; }

    public TranspilerException(string? message, string? gilCode = null) : base(message)
    {
        GilCode = gilCode;
    }

    public TranspilerException(string? message, Exception? innerException = null, string? gilCode = null) : base(message, innerException)
    {
        GilCode = gilCode;
    }
}
