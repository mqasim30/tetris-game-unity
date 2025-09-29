using System.Threading;
using TetrisGame.Core.Scripts.Services.SceneLoader.Base;
using UnityEngine;

namespace TetrisGame.Core.Scripts.Services.InitiatorInvokerService.Base
{
    public interface ISceneInitiator
    {
        SceneType SceneType { get; }
        Awaitable LoadEntryPoint(CancellationTokenSource cancellationTokenSource);
        Awaitable StartEntryPoint(CancellationTokenSource cancellationTokenSource);
        Awaitable InitExitPoint(CancellationTokenSource cancellationTokenSource);
    }
}