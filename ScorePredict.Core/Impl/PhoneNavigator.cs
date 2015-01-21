using System.Linq;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.Impl
{
    public class PhoneNavigator : INavigator
    {
        public async Task ShowPageAsRootAsync(INavigation navigation, Page rootPage)
        {
            await navigation.PushAsync(rootPage, true);
            Page firstPage = navigation.NavigationStack.FirstOrDefault(p => p.GetType() != rootPage.GetType());

            while (firstPage != null)
            {
                navigation.RemovePage(firstPage);
                firstPage = navigation.NavigationStack.FirstOrDefault(p => p.GetType() != rootPage.GetType());
            } 
        }

        public async Task ShowPageAsync(INavigation navigation, Page newPage)
        {
            await navigation.PushAsync(newPage, true);
        }
    }
}
