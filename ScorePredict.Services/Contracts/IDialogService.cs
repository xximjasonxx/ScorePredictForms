using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScorePredict.Services.Contracts
{
    public interface IDialogService
    {
        void ShowLoading(string message = "Loading");
        void HideLoading();
        Task<bool> ConfirmLogoutAsync();
    }
}
