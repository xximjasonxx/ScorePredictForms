using System;
using System.Linq;
using ScorePredict.Common.Injection;
using ScorePredict.Core.Pages;
using Xamarin.Forms;

namespace ScorePredict.Core
{
    public class PhonePageHelper : IPageHelper
    {
        private INavigation NavigationProperty
        {
            get { return Resolver.CurrentResolver.GetInstance<INavigation>(); }
        }

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
                var typesMatch = page.GetType() == typeof(T);

                while (!typesMatch)
                {
                    NavigationProperty.RemovePage(page);

                    page = stack.FirstOrDefault();
                    if (page == null)
                        throw new InvalidOperationException("Could not find the requested page");

                    typesMatch = page.GetType() == typeof(T);
                }
            }
        }
    }
}
