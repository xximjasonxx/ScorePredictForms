using System;
using ScorePredict.Common.Data;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Services.Impl
{
    public class ScorePredictStartupService : IStartupService
    {
        public IClient Client { get; private set; }

        public ScorePredictStartupService(IClient client)
        {
            Client = client;
        }

        public void SetUser(User user)
        {
            Client.AuthenticateUser(user);
        }
    }
}
