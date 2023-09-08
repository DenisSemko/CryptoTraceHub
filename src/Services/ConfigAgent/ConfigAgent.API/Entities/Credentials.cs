namespace ConfigAgent.API.Entities;

public class Credentials
{
    public Guid Id { get; set; }
    public string EncryptedCredentials { get; set; }
    public CoinApiType CoinApiType { get; set; }
}