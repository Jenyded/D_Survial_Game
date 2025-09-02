using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace _Project.Scripts.Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider
    {
        UniTask<GameObject> CreateGameObject(string address, Transform parent = null);
        UniTask<T> LoadObject<T>(string addressKey);
    }
}