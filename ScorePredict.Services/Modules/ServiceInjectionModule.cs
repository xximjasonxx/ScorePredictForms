using Autofac;
using ScorePredict.Services.Contracts;
using ScorePredict.Services.Impl;
using ScorePredict.Services.Impl.Mock;

namespace ScorePredict.Services.Modules
{
    public class ServiceInjectionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ScorePredictCreateUserService>().As<ICreateUserService>();
            builder.RegisterType<ScorePredictLoginUserService>().As<ILoginUserService>();
            builder.RegisterType<ScorePredictGetUsernameService>().As<IGetUsernameService>();
            builder.RegisterType<ScorePredictSetUsernameService>().As<ISetUsernameService>();
            builder.RegisterType<ScorePredictThisWeekService>().As<IThisWeekService>();
            builder.RegisterType<ScorePredictPredictionService>().As<IPredictionService>();
            builder.RegisterType<ScorePredictStartupService>().As<IStartupService>();

            // mocks
            /*builder.RegisterType<MockLoginUserService>().As<ILoginUserService>();
            builder.RegisterType<MockThisWeekService>().As<IThisWeekService>();
            builder.RegisterType<MockPredictionService>().As<IPredictionService>();
            builder.RegisterType<MockGetUsernameService>().As<IGetUsernameService>();*/
        }
    }
}
