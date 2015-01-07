using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Injection;
using ScorePredict.Phone.Client;
using ScorePredict.Services.Client;

namespace ScorePredict.Phone
{
    public class PhoneInjectionModule : InjectionModule
    {
        public PhoneInjectionModule()
        {
            AddDependency<IClient>(typeof(AzureMobileServiceClient));
        }
    }
}
