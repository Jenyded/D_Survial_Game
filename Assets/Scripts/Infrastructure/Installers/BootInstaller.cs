using _Project.Code.Infrastructure;
using _Project.Scripts.Infrastructure.Data;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.Services;
using _Project.Scripts.Infrastructure.Services.AssetProvider;
using _Project.Scripts.Infrastructure.Services.Input;
using _Project.Scripts.Infrastructure.Services.PersistentData;
using _Project.Scripts.Infrastructure.Services.SaveLoad;
using _Project.Scripts.Infrastructure.Services.SceneLoader;
using _Project.Scripts.Infrastructure.Services.WindowsService;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States;
using Services;
using Services.Interfaces;
using UnityEngine;
using Zenject;

// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace _Project.Scripts.Infrastructure.Installers
{
    public class BootInstaller : MonoInstaller
    {
        [SerializeField] private EntryFinder _entryFinder;
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private Scenes _scenes;

        private IGameFactory _gameFactory;
        private ISaveLoadService _saveLoadService;
        private IPersistentDataService _persistentDataService;
        private IInputService _inputService;
        private IAssetProvider _assetProvider;
        private IConfigService _configService;
        private ISceneLoader _sceneLoader;
        private GameStateMachine _gameStateMachine;
        private IWindowsService _windowsService;


        public override void InstallBindings()
        {
            BindScenes();
            BindCoroutineRunner();
            BindConfigService();
            BindWindowsService();
            BindSceneLoader();
            BindInput();
            BindAssetProvider();
            BindGameFactory();
            BindPersistentService();
            BindSaveLoadService();
            BindGameStateMachine();
        }

        private void BindAssetProvider()
        {
            _assetProvider = new AssetProvider(Container);
            Container.BindInterfacesAndSelfTo<IAssetProvider>().FromInstance(_assetProvider).AsSingle();
        }

        private void BindWindowsService()
        {
            _windowsService = new WindowsService(_configService);
            Container.BindInterfacesAndSelfTo<IWindowsService>().FromInstance(_windowsService).AsSingle();
        }

        private void BindSceneLoader()
        {
            _sceneLoader = new SceneLoader(_coroutineRunner, _windowsService);
            Container.BindInterfacesAndSelfTo<ISceneLoader>().FromInstance(_sceneLoader).AsSingle();
        }

        private void BindGameStateMachine()
        {
            _gameStateMachine = new GameStateMachine(_entryFinder, _gameFactory, _scenes, _saveLoadService,
                _persistentDataService,
                _configService, _sceneLoader, _windowsService);

            Container.BindInterfacesAndSelfTo<GameStateMachine>().FromInstance(_gameStateMachine).AsSingle();
        }

        private void BindScenes()
        {
            Container.BindInstance(_scenes).AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container.BindInterfacesAndSelfTo<ICoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
        }

        private void BindInput()
        {
            _inputService = new MobileInputService();
            Container.BindInterfacesAndSelfTo<IInputService>().FromInstance(_inputService).AsSingle();
        }

        private void BindGameFactory()
        {
            _gameFactory = new GameFactory(_configService, _assetProvider, _inputService, new SkillFactory(_configService));
            Container.BindInterfacesAndSelfTo<IGameFactory>().FromInstance(_gameFactory).AsSingle();
        }

        private void BindConfigService()
        {
            _configService = new ConfigService();
            Container.BindInterfacesAndSelfTo<IConfigService>().FromInstance(_configService).AsSingle();
        }

        private void BindPersistentService()
        {
            _persistentDataService = new PersistentDataService();
            Container.BindInterfacesAndSelfTo<IPersistentDataService>().FromInstance(_persistentDataService).AsSingle();
        }

        private void BindSaveLoadService()
        {
            _saveLoadService = new SaveLoadService(_persistentDataService);
            Container.BindInterfacesAndSelfTo<ISaveLoadService>().FromInstance(_saveLoadService).AsSingle();
        }
    }
}