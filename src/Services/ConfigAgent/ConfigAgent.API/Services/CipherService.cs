namespace ConfigAgent.API.Services;

public class CipherService : ICipherService
{
    private readonly ICipherConfiguration _cipherConfiguration;
    
    public CipherService(ICipherConfiguration cipherConfiguration)
    {
        _cipherConfiguration = cipherConfiguration;
    }
    
    public string Encrypt(string plainText)
    {
        byte[] encrypted;

        if (string.IsNullOrWhiteSpace(plainText))
            throw new ArgumentNullException(nameof(plainText));

        using (Aes aes = Aes.Create())
        {
            ICryptoTransform encryptor = aes.CreateEncryptor(StringToByteArray(_cipherConfiguration.SecretKeyHex), StringToByteArray(_cipherConfiguration.IvHex));

            using (MemoryStream memoryStream = new ())
            {
                using (CryptoStream cryptoStream = new (memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new (cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }
                    encrypted = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    public string Decrypt(string encryptedString)
    {
        string plainText = String.Empty;

        if (string.IsNullOrWhiteSpace(encryptedString))
            throw new ArgumentNullException(nameof(encryptedString));

        using (Aes aes = Aes.Create())
        {
            ICryptoTransform decryptor = aes.CreateDecryptor(StringToByteArray(_cipherConfiguration.SecretKeyHex), StringToByteArray(_cipherConfiguration.IvHex));

            using (MemoryStream memoryStream = new (Convert.FromBase64String(encryptedString)))
            {
                using (CryptoStream cryptoStream = new (memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new (cryptoStream))
                    {
                        plainText = streamReader.ReadToEnd();
                    }
                }
            }
        }

        return plainText;
    }
    
    private byte[] StringToByteArray(string hex)
    {
        int numberChars = hex.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }
}