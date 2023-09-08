namespace ConfigAgent.API.Consumers;

public class CheckCredentialsConsumer : IConsumer<CheckCredentialsEvent>
{
    private readonly ICredentialsService _credentialsService;

    public CheckCredentialsConsumer(ICredentialsService credentialsService)
    {
        _credentialsService = credentialsService ?? throw new ArgumentNullException(nameof(credentialsService));
    }

    public async Task Consume(ConsumeContext<CheckCredentialsEvent> context)
    {
        CredentialsModel credentials = context.Message.CoinApiType == CoinApiType.CoinMarketCap ? await _credentialsService.Get() : default;

        if (credentials is not null)
        {
            await context.RespondAsync(new CredentialsTransferEvent()
            {
                ApiKey = credentials.ApiKey,
                BaseUrl = credentials.BaseUrl
            });
        }
    }
}