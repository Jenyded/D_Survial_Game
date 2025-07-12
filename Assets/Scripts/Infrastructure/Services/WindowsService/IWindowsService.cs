using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Infrastructure.Services.WindowsService
{
    public interface IWindowsService
    {
        UniTask Load();
        void ToggleLoadingScreenTo(bool active);
        void RefreshLoadingProgress(float value);
    }
}