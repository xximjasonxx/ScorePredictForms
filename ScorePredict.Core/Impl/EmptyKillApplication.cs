using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;

namespace ScorePredict.Core.Impl
{
    public class EmptyKillApplication : IKillApplication
    {
        public void KillApp()
        {
            // do nothing
        }
    }
}
