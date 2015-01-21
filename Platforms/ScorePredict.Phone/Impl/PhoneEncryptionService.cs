using System;
using System.Security.Cryptography;
using System.Text;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Phone.Impl
{
    public class PhoneEncryptionService : IEncryptionService
    {
        public string Encrypt(string plainValue)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainValue);
            byte[] encryptedBytes = ProtectedData.Protect(plainBytes, null);

            return Convert.ToBase64String(encryptedBytes);
        }

        public string Decrypt(string encryptedValue)
        {
            byte[] encyrptedBytes = Convert.FromBase64String(encryptedValue);
            byte[] plainBytes = ProtectedData.Unprotect(encyrptedBytes, null);

            return Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);
        }
    }
}
