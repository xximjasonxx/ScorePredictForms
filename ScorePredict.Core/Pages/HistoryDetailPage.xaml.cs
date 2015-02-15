using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScorePredict.Common.Extensions;
using ScorePredict.Core.ViewModels;
using Xamarin.Forms;

namespace ScorePredict.Core.Pages
{
    public partial class HistoryDetailPage
    {
        public HistoryDetailPage(int selectedYear)
            : base(new Dictionary<string, string> { { "Year", selectedYear.ToString() } })
        {
            InitializeComponent();
        }

        public override void ApplyViewModelParameters(ViewModelBase viewModel, IDictionary<string, string> parameters)
        {
            var year = parameters["Year"].AsInt();
            ((HistoryDetailViewModel) viewModel).Year = year;
        }

        public override Type ViewModelType
        {
            get { return typeof (HistoryDetailViewModel); }
        }
    }
}
