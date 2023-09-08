namespace ConfigAgent.API.Exceptions;

public class AgentException : ApplicationException
{
    public string Message { get; set; }
    public int StatusCode { get; set; }

    public AgentException() : base() { }

    public AgentException(string message, int statusCode) : base(message)
    {
        Message = message;
        StatusCode = statusCode;
    }
}