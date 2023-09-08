namespace ConfigAgent.API.Mapper.Converters;

public class CredentialsToCredentialsModel : ITypeConverter<Credentials, CredentialsModel>
{
    public CredentialsModel Convert(Credentials source, CredentialsModel destination, ResolutionContext context)
    {
        ICipherService cipherService = CipherLocator.GetService<ICipherService>();
        string decryptedCredentials = cipherService.Decrypt(source.EncryptedCredentials);
        string[] credentials = decryptedCredentials.Split(";");
        
        return new CredentialsModel()
        {
            ApiKey = credentials[0],
            BaseUrl = credentials[1]
        };
    }
}