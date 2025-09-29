using System.Threading;
using UnityEngine;

namespace TetrisGame.Core.Scripts.MVC.LoadingScreen.Base
{
    public interface ILoadingScreenController
    {
        void Show();
        void Hide();
        void ResetSlider();
        Awaitable SetLoadingSlider(float valueBetween0To1, CancellationTokenSource cancellationTokenSource);
    }
}