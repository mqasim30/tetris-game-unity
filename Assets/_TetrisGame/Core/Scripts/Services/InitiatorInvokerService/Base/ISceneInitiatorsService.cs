using System.Threading;
using TetrisGame.Core.Scripts.Services.SceneLoader.Base;
using UnityEngine;

namespace TetrisGame.Core.Scripts.Services.InitiatorInvokerService.Base
{
    public interface ISceneInitiatorsService
    {
        void RegisterInitiator(ISceneInitiator sceneInitiator);
        void UnregisterInitiator(ISceneInitiator sceneInitiator);

        Awaitable InvokeInitiatorLoadEntryPoint(SceneType sceneType,
            CancellationTokenSource cancellationTokenSource);

        Awaitable InvokeInitiatorStartEntryPoint(SceneType sceneType,
            CancellationTokenSource cancellationTokenSource);

        Awaitable InvokeInitiatorExitPoint(SceneType sceneType, CancellationTokenSource cancellationTokenSource);
    }
}