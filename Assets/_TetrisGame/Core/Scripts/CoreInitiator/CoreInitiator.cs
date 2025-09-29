using System;
using System.Threading;
using TetrisGame.Core.Scripts.MVC.LoadingScreen.Base;
using UnityEngine;
using TetrisGame.Core.Scripts.Services.Logger.Base;
using TetrisGame.Core.Scripts.Services.SceneLoader.Base;
using Zenject;

namespace TetrisGame.Core.Scripts.CoreInitiator
{
    public class CoreInitiator : MonoBehaviour
    {
        private ISceneLoaderService _sceneLoaderService;
        private ILoadingScreenController _loadingScreenController;

        [Inject]
        private void Setup(ISceneLoaderService sceneLoaderService,
            ILoadingScreenController loadingScreenController)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreenController = loadingScreenController;
        }

        private void Start()
        {
            _ = InitEntryPoint(CancellationTokenSource.CreateLinkedTokenSource(Application.exitCancellationToken));
        }

        private async Awaitable InitEntryPoint(CancellationTokenSource cancellationTokenSource)
        {
            try
            {
                UpdateApplicationSettings();
                _loadingScreenController.Show();
                InitializeServices();
                await LoadGameScene(cancellationTokenSource);
                await _loadingScreenController.SetLoadingSlider(1, cancellationTokenSource);
            }
            catch (OperationCanceledException)
            {
                LogService.Log("Operation init core was cancelled");
            }
            catch (Exception e)
            {
                LogService.LogError(e.Message);
                throw;
            }

            _loadingScreenController.Hide();
        }

        private void UpdateApplicationSettings()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            Application.targetFrameRate = 60;
        }

        private void InitializeServices()
        {
            _sceneLoaderService.InitEntryPoint();
        }

        private async Awaitable LoadGameScene(CancellationTokenSource cancellationTokenSource)
        {
            await _sceneLoaderService.TryLoadScene(SceneType.GameScene,
                cancellationTokenSource);
        }
    }
}