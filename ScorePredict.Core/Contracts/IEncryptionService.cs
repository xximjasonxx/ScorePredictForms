using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Core.Contracts
{
    public interface IEncryptionService
    {
        string Encrypt(string plainValue);
        string Decrypt(string encryptedValue);
    }
}
