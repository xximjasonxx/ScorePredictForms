using System.Linq;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.Impl
{
    public abstract class NavigatorBase : INavigator
    {
        public virtual async Task ShowPageAsRootAsync(INavigation navigation, Page rootPage)
        {
            navigation.InsertPageBefore(rootPage, navigation.NavigationStack.First());
            await navigation.PopToRootAsync(true);
        }

        public virtual async Task ShowPageAsync(INavigation navigation, Page newPage)
        {
            await navigation.PushAsync(newPage);
        }

        public async Task ShowModalAsync(INavigation navigation, Page newPage)
        {
            await navigation.PushModalAsync(newPage, true);
        }
    }
}
