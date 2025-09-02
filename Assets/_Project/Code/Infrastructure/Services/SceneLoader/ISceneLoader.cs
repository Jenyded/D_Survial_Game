using System;

namespace _Project.Scripts.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader
    {
        void LoadScene(string scene, Action onLoaded);
    }
}