using System;
using System.Collections;
using _Project.Scripts.Infrastructure.Services.WindowsService;
using _Project.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IWindowsService _windowsService;

        public SceneLoader(ICoroutineRunner coroutineRunner, IWindowsService windowsService)
        {
            _coroutineRunner = coroutineRunner;
            _windowsService = windowsService;
        }
        
        public void LoadScene(string scene, Action onLoaded)
        {
            _coroutineRunner.Run(Loading(scene, onLoaded));
        }

        private IEnumerator Loading(string scene, Action onLoaded)
        {
            _windowsService.ToggleLoadingScreenTo(true);

            if (SceneManager.GetActiveScene().name != scene)
            {
                AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(scene);
                while (!loadingOperation.isDone)
                {
                    _windowsService.RefreshLoadingProgress(loadingOperation.progress);
                    yield return null;
                }
            }
            
            onLoaded?.Invoke();
            _windowsService.ToggleLoadingScreenTo(false);
        }
    }
}