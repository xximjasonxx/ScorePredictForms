using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ScorePredict.Core.Contracts
{
    public interface INavigator
    {
        Task ShowPageAsRootAsync(INavigation navigation, Page rootPage);
        Task ShowPageAsync(INavigation navigation, Page newPage);
    }
}
