using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace CardVault.Shared.Infrastructure.Utils
{
    public static class TokenizationService
    {
        private static readonly string? EncryptionKey = Environment.GetEnvironmentVariable("ENCRYPTION_KEY",
            EnvironmentVariableTarget.Process);
       
        public static string Tokenize<T>(T sensitiveData)
        {
            if (sensitiveData == null)
                throw new ArgumentNullException(nameof(sensitiveData));
            
            string jsonData = JsonSerializer.Serialize(sensitiveData);

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aes.IV = new byte[16];

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    byte[] sensitiveBytes = Encoding.UTF8.GetBytes(jsonData);
                    cs.Write(sensitiveBytes, 0, sensitiveBytes.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
//8080
        public static T Detokenize<T>(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentNullException(nameof(token));

            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(EncryptionKey);
                aes.IV = new byte[16];

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(Convert.FromBase64String(token)))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs))
                {
                    string jsonData = reader.ReadToEnd();
                    
                    return JsonSerializer.Deserialize<T>(jsonData);
                }
            }
        }
    }
}
