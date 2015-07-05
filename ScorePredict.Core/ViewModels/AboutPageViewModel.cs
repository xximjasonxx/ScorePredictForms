using ScorePredict.Core.Contracts;
using ScorePredict.Core.ViewModels.Abstract;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.ViewModels
{
    public class AboutPageViewModel : ScorePredictRootPageViewModel
    {
        public AboutPageViewModel(IClearUserSecurityService clearUserSecurityService, IDialogService dialogService,
            IKillApplication killApplication)
            : base(clearUserSecurityService, dialogService, killApplication)
        {
        }
    }
}
