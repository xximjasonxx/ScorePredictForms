using System.Windows.Input;
using Xamarin.Forms;

namespace ScorePredict.Core.Controls
{
    public class ScorePredictListView : ListView
    {
        public static BindableProperty ItemSelectedCommandProperty =
            BindableProperty.Create<ScorePredictListView, ICommand>(x => x.ItemSelectedCommand, null);

        public ScorePredictListView()
        {
            ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem;
            if (item != null && ItemSelectedCommand != null && ItemSelectedCommand.CanExecute(item))
            {
                ItemSelectedCommand.Execute(e.SelectedItem);
            }

            SelectedItem = null;
        }

        public ICommand ItemSelectedCommand
        {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }
    }
}
