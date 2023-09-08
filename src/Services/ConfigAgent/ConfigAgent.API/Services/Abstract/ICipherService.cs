namespace ConfigAgent.API.Services.Abstract;

public interface ICipherService
{
    string Encrypt(string plainText);
    string Decrypt(string encryptedString);
}