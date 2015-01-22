using System.Linq;
using System.Threading.Tasks;
using ScorePredict.Core.Contracts;
using Xamarin.Forms;

namespace ScorePredict.Core.Impl
{
    public class PhoneNavigator : NavigatorBase
    {
        public override async Task ShowPageAsRootAsync(INavigation navigation, Page rootPage)
        {
            await navigation.PushAsync(rootPage, true);
            Page firstPage = navigation.NavigationStack.FirstOrDefault(p => p.GetType() != rootPage.GetType());

            while (firstPage != null)
            {
                navigation.RemovePage(firstPage);
                firstPage = navigation.NavigationStack.FirstOrDefault(p => p.GetType() != rootPage.GetType());
            } 
        }
    }
}
