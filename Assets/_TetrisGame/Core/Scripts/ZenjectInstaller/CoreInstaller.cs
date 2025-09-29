using TetrisGame.Core.Scripts.Mvc.LoadingScreen;
using TetrisGame.Core.Scripts.Services.InitiatorInvokerService;
using TetrisGame.Core.Scripts.Services.Logger;
using TetrisGame.Core.Scripts.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace TetrisGame.Core.Scripts.ZenjectInstaller
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private LoadingScreenView _loadingScreenView;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnityLoggerService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneLoaderService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneInitiatorsService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<LoadingScreenController>().AsSingle().WithArguments(_loadingScreenView)
                .NonLazy();
        }
    }
}