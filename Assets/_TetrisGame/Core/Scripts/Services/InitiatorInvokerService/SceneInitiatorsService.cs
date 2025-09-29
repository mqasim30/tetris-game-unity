using System.Collections.Generic;
using System.Threading;
using TetrisGame.Core.Scripts.Services.InitiatorInvokerService.Base;
using TetrisGame.Core.Scripts.Services.SceneLoader.Base;
using UnityEngine;

namespace TetrisGame.Core.Scripts.Services.InitiatorInvokerService
{
    public class SceneInitiatorsService : ISceneInitiatorsService
    {
        private readonly Dictionary<SceneType, ISceneInitiator> _sceneInitiators =
            new Dictionary<SceneType, ISceneInitiator>();

        public void RegisterInitiator(ISceneInitiator sceneInitiator)
        {
            _sceneInitiators.Add(sceneInitiator.SceneType, sceneInitiator);
        }

        public void UnregisterInitiator(ISceneInitiator sceneInitiator)
        {
            _sceneInitiators.Remove(sceneInitiator.SceneType);
        }

        public async Awaitable InvokeInitiatorLoadEntryPoint(SceneType sceneType,
            CancellationTokenSource cancellationTokenSource)
        {
            await _sceneInitiators[sceneType].LoadEntryPoint(cancellationTokenSource);
        }

        public async Awaitable InvokeInitiatorStartEntryPoint(SceneType sceneType,
            CancellationTokenSource cancellationTokenSource)
        {
            await _sceneInitiators[sceneType].StartEntryPoint(cancellationTokenSource);
        }

        public async Awaitable InvokeInitiatorExitPoint(SceneType sceneType,
            CancellationTokenSource cancellationTokenSource)
        {
            await _sceneInitiators[sceneType].InitExitPoint(cancellationTokenSource);
        }
    }
}