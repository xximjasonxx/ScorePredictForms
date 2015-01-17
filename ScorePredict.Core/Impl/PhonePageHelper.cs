using System;
using System.Linq;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Contracts;
using ScorePredict.Core.Pages;
using Xamarin.Forms;

namespace ScorePredict.Core.Impl
{
    public class PhonePageHelper : IPageHelper
    {
        private INavigation NavigationProperty
        {
            get { return Resolver.CurrentResolver.GetInstance<INavigation>(); }
        }

        /* dont use the PageFactory - no navigation controller concept in Windows Phone */

        public void ShowLogin()
        {
            NavigationProperty.PushAsync(new LoginPage());
            ClearStackTo<LoginPage>();
        }

        public void ShowMain()
        {
            NavigationProperty.PushAsync(new MainPage());
            ClearStackTo<MainPage>();
        }

        private void ClearStackTo<T>() where T : Page
        {
            var stack = NavigationProperty.NavigationStack;
            if (stack.Count > 1)
            {
                var page = stack.First();
                if (page.GetType() == typeof (NavigationPage))
                    page = ((NavigationPage) page).CurrentPage;

                var typesMatch = page.GetType() == typeof(T);

                while (!typesMatch)
                {
                    NavigationProperty.RemovePage(page);

                    page = stack.FirstOrDefault();
                    if (page == null)
                        throw new InvalidOperationException("Could not find the requested page");

                    if (page is NavigationPage)
                        page = ((NavigationPage) page).CurrentPage;

                    typesMatch = page.GetType() == typeof(T);
                }
            }
        }
    }
}
