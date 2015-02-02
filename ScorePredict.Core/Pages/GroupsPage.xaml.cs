using System;
using ScorePredict.Core.ViewModels;

namespace ScorePredict.Core.Pages
{
    public partial class GroupsPage
    {
        public GroupsPage()
        {
            InitializeComponent();
        }

        public override Type ViewModelType
        {
            get { return typeof (GroupsPageViewModel); }
        }
    }
}
