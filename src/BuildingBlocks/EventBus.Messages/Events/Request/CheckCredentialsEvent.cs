using EventBus.Messages.Common;

namespace EventBus.Messages.Events.Request;

public class CheckCredentialsEvent
{
    public CoinApiType CoinApiType { get; set; }
}