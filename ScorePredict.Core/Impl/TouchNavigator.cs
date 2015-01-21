using System;
using System.Linq;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.Impl
{
    public class TouchNavigator : INavigator
    {
        public async Task ShowPageAsRootAsync(INavigation navigation, Page rootPage)
        {
            navigation.InsertPageBefore(rootPage, navigation.NavigationStack.First());
            await navigation.PopToRootAsync(true);
        }

        public async Task ShowPageAsync(INavigation navigation, Page newPage)
        {
            await navigation.PushAsync(newPage);
        }
    }
}
