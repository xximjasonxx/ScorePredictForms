using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string plainValue);
        string Decrypt(string encryptedValue);
    }
}
