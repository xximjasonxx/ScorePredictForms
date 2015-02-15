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
            builder.RegisterType<CreateUserPageViewModel>();
            builder.RegisterType<ThisWeekPageViewModel>();
            builder.RegisterType<GroupsPageViewModel>();
            builder.RegisterType<HistoryPageViewModel>();
            builder.RegisterType<HistoryDetailViewModel>();
            builder.RegisterType<PredictionsPageViewModel>();
            builder.RegisterType<PredictionEditViewModel>();
            builder.RegisterType<RankingsViewModel>();
            builder.RegisterType<AboutPageViewModel>();
        }
    }
}
