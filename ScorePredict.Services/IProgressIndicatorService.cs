using System;

namespace ScorePredict.Services
{
    public interface IProgressIndicatorService
    {
        void Show(string message = "");
        void Hide();
    }
}

