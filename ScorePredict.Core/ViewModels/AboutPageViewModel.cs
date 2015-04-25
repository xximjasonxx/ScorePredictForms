using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.ViewModels
{
    public class AboutPageViewModel : ScorePredictBaseViewModel
    {
        public AboutPageViewModel(IClearUserSecurityService clearUserSecurityService, INavigator navigator, IDialogService dialogService,
            IKillApplication killApplication)
            : base(clearUserSecurityService, navigator, dialogService, killApplication)
        {
        }
    }
}
