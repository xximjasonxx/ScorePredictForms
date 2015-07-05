using System.Collections.Generic;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels.Abstract
{
    public abstract class ScorePredictRootPageViewModel : ScorePredictBaseViewModel
    {
        public IKillApplication KillApplication { get; private set; }

        protected ScorePredictRootPageViewModel(IClearUserSecurityService clearUserSecurityService, IDialogService dialogService, 
            IKillApplication killApplication)
            : base(clearUserSecurityService, dialogService)
        {
            KillApplication = killApplication;            
        }

        public override bool BackButtonPressed()
        {
            KillApplication.KillApp();
            return true;
        }
    }
}
