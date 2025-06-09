using _Project.Scripts.Infrastructure.Factories;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Services
{
    public class MetaEntry : MonoBehaviour, IEntryPoint
    {
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        
        public async void Initialize()
        {
            await CreateRuntime();
            await CreateUI();
        }

        private async UniTask CreateRuntime()
        {
            
        }

        private async UniTask CreateUI()
        {
            
        }
    }
}