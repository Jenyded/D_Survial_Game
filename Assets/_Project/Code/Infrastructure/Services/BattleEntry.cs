using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.Services.WindowsService;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Services
{
    public class BattleEntry : MonoBehaviour, IEntryPoint
    {
        [SerializeField] private BattleCamera _camera;
        
        private IGameFactory _gameFactory;
        private IWindowsService _windowsService;

        [Inject]
        private void Construct(IGameFactory gameFactory, IWindowsService windowsService)
        {
            _gameFactory = gameFactory;
            _windowsService = windowsService;
        }
        
        public async void Initialize()
        {
            await CreateRuntime();
            await CreateUI();
        }

        private async UniTask CreateRuntime()
        {
            GameObject character = await _gameFactory.CreateCharacter(CharacterId.Druid);
            
            _camera.FollowTo(character.transform);
        }

        private async UniTask CreateUI()
        {
            await _gameFactory.CreateHud();
        }
    }
}