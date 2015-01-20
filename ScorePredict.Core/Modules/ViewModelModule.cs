using Autofac;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Modules
{
    public class ViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainPageViewModel>();
            builder.RegisterType<LoginPageViewModel>();
            builder.RegisterType<EnterUsernamePageViewModel>();
        }
    }
}
