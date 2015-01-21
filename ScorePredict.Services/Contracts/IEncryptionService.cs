namespace ScorePredict.Services.Contracts
{
    public interface IEncryptionService
    {
        string Encrypt(string plainValue);
        string Decrypt(string encryptedValue);
    }
}
