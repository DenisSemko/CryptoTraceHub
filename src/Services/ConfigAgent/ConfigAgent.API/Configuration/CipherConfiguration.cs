namespace ConfigAgent.API.Configuration;

public class CipherConfiguration : ICipherConfiguration
{
    public string SecretKeyHex { get; set; }
    public string IvHex { get; set; }
}