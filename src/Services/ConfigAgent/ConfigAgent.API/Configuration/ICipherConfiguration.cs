namespace ConfigAgent.API.Configuration;

public interface ICipherConfiguration
{
    string SecretKeyHex { get; set; }
    string IvHex { get; set; }
}