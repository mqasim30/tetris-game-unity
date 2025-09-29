using System.Threading;
using UnityEngine;

namespace TetrisGame.Core.Scripts.Services.SceneLoader.Base
{
    public interface ISceneLoaderService
    {
        void InitEntryPoint();

        Awaitable<bool> TryLoadScene(SceneType sceneType,
            CancellationTokenSource cancellationTokenSource);

        Awaitable StartScene(SceneType gamePlayScene,
            CancellationTokenSource cancellationTokenSource);

        Awaitable<bool> TryUnloadScene(SceneType sceneType, CancellationTokenSource cancellationTokenSource);
    }
}