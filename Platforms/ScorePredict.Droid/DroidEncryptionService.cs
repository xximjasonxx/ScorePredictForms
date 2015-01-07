using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ScorePredict.Services;

namespace ScorePredict.Droid
{
    public class DroidEncryptionService : IEncryptionService
    {
        private const string EncryptionSalt = "Xamarin.Forms";
        private const string EncryptionPassword = "HelloXamarin";

        public string Encrypt(string plainValue)
        {
            byte[] salt = Encoding.ASCII.GetBytes(EncryptionSalt);
            var key = new Rfc2898DeriveBytes(EncryptionPassword, salt);

            // Declare that we are going to use the Rijndael algorithm with the key that we've just got.
            var algorithm = new RijndaelManaged();
            int bytesForKey = algorithm.KeySize / 8;
            int bytesForIv = algorithm.BlockSize / 8;
            algorithm.Key = key.GetBytes(bytesForKey);
            algorithm.IV = key.GetBytes(bytesForIv);

            byte[] encryptedBytes;
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
            {
                byte[] bytesToEncrypt = Encoding.UTF8.GetBytes(plainValue);
                encryptedBytes = InMemoryCrypt(bytesToEncrypt, encryptor);
            }
            
            return Convert.ToBase64String(encryptedBytes);
        }

        private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
        {
            MemoryStream memory = new MemoryStream();
            using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
            {
                stream.Write(data, 0, data.Length);
            }
            return memory.ToArray();
        }

        public string Decrypt(string encryptedValue)
        {
            byte[] salt = Encoding.ASCII.GetBytes(EncryptionSalt);
            var key = new Rfc2898DeriveBytes(EncryptionPassword, salt);

            // Declare that we are going to use the Rijndael algorithm with the key that we've just got.
            var algorithm = new RijndaelManaged();
            int bytesForKey = algorithm.KeySize / 8;
            int bytesForIV = algorithm.BlockSize / 8;
            algorithm.Key = key.GetBytes(bytesForKey);
            algorithm.IV = key.GetBytes(bytesForIV);

            byte[] descryptedBytes;
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
            {
                byte[] encryptedBytes = Convert.FromBase64String(encryptedValue);
                descryptedBytes = InMemoryCrypt(encryptedBytes, decryptor);
            }
            
            return Encoding.UTF8.GetString(descryptedBytes);
        }
    }
}