using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using ScorePredict.Services.Contracts;

namespace ScorePredict.Core.ViewModels.Abstract
{
    public class ScorePredictRootViewModelBase : ScorePredictBaseViewModel
    {
        public IKillApplication KillApplication { get; private set; }

        protected ScorePredictRootViewModelBase(IClearUserSecurityService clearUserSecurityService, INavigator navigator,
            IDialogService dialogService, IKillApplication killApplication)
            : base(clearUserSecurityService, navigator, dialogService)
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
