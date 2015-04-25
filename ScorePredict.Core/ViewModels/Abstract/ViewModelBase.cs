using System.ComponentModel;
using System.Runtime.CompilerServices;
using ScorePredict.Core.Annotations;
using Xamarin.Forms;

namespace ScorePredict.Core.ViewModels.Abstract
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

        protected INavigation Navigation { get { return ScorePredictApplication.Navigation; } }

        public virtual void OnShow()
        {
            // do nothing
        }

        public virtual bool BackButtonPressed()
        {
            return true;
        }
    }
}
