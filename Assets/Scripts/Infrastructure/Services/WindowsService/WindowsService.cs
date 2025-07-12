using _Project.Scripts.UI;
using Cysharp.Threading.Tasks;
using Services.Interfaces;
using UnityEngine.AddressableAssets;

namespace _Project.Scripts.Infrastructure.Services.WindowsService
{
    public class WindowsService : IWindowsService
    {
        
        private LoadingScreen _loadingScreen;
        private readonly IConfigService _configService;

        public WindowsService(IConfigService configService)
        {
            _configService = configService;
        }

        public async UniTask Load()
        {
            var loadingScreenInstance = await Addressables.InstantiateAsync(_configService.ForUI().LoadingScreenPrefab);
            _loadingScreen = loadingScreenInstance.GetComponent<LoadingScreen>();
        }

        public void ToggleLoadingScreenTo(bool active)
        {
            if (active)
            {
                _loadingScreen.Show();
                return;
            }
            
            _loadingScreen.Hide();
        }

        public void RefreshLoadingProgress(float value) => _loadingScreen.Progress = value;
    }
}