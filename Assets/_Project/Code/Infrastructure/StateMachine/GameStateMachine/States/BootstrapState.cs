using _Project.Scripts.Infrastructure.Data;
using _Project.Scripts.Infrastructure.Services.PersistentData;
using _Project.Scripts.Infrastructure.Services.SaveLoad;
using _Project.Scripts.Infrastructure.Services.WindowsService;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States.Interfaces;
using Services.Interfaces;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IConfigService _configService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IWindowsService _windowsService;
        private readonly IPersistentDataService _persistent;
        private readonly Scenes _scenes;

        public BootstrapState(GameStateMachine gameStateMachine, Scenes scenes, IConfigService configService,IPersistentDataService persistent,
            ISaveLoadService saveLoadService, IWindowsService windowsService)
        {
            _gameStateMachine = gameStateMachine;
            _scenes = scenes;
            _configService = configService;
            _persistent = persistent;
            _saveLoadService = saveLoadService;
            _windowsService = windowsService;
        }

        public async void Enter()
        {
            LoadProgress();
            
            await _configService.Load();
            await _windowsService.Load();
            
            _gameStateMachine.Enter<LoadSceneState>();
        }

        private void LoadProgress()
        {
            PlayerProgress progress = _saveLoadService.Load();

            if (progress == null)
                progress = CreateNewProgress();
            
            _persistent.Progress = progress;
        }

        private PlayerProgress CreateNewProgress()
        {
            PlayerProgress progress = new PlayerProgress
            {
                SaveVersion = "1.0",
                BattleData = new()
                {
                    EnemyKilled = new(0)
                }
            };

            return progress;
        }

        public void Exit()
        {
            
        }
    }
}
