using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ScorePredict.Core.Annotations;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task ShowPage(Page page)
        {
            await ScorePredictApplication.Navigation.PushAsync(page, true);
        }

        protected async Task PopModal()
        {
            await ScorePredictApplication.Navigation.PopModalAsync(true);
        }
    }
}
