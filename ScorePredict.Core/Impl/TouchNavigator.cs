using System;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.Impl
{
    public class TouchNavigator : INavigator
    {
        public Task ShowPageAsRootAsync(INavigation navigation, Page rootPage)
        {
            throw new NotImplementedException();
        }

        public Task ShowPageAsync(INavigation navigation, Page newPage)
        {
            throw new NotImplementedException();
        }
    }
}
