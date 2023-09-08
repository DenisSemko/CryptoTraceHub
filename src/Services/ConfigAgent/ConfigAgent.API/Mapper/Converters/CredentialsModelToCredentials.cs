namespace ConfigAgent.API.Mapper.Converters;

public class CredentialsModelToCredentials : ITypeConverter<CredentialsModel, Credentials>
{
    public Credentials Convert(CredentialsModel source, Credentials destination, ResolutionContext context)
    {
        ICipherService cipherService = CipherLocator.GetService<ICipherService>();
        string credentialsToEncrypt = $"{source.ApiKey};{source.BaseUrl}";
        string encryptedCredentials = cipherService.Encrypt(credentialsToEncrypt);

        destination.EncryptedCredentials = encryptedCredentials;
        return destination;
    }
}