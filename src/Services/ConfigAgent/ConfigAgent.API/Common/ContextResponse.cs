namespace ConfigAgent.API.Common;

public sealed record ContextResponse(string Message, string Type, string StackTrace);