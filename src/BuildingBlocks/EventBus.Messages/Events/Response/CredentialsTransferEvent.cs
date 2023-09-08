namespace EventBus.Messages.Events.Response;

public class CredentialsTransferEvent : IntegrationBaseEvent
{
    public string ApiKey { get; set; }
    public string BaseUrl { get; set; }
}