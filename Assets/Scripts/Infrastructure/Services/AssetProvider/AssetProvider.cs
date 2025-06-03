using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace _Project.Scripts.Infrastructure.Services.AssetProvider
{
    public class AssetProvider : IAssetProvider
    {
        private readonly DiContainer _container;

        public AssetProvider(DiContainer container)
        {
            _container = container;
        }
        
        public async UniTask<T> LoadObject<T>(string addressKey)
        {
            T resultObject = await Addressables.LoadAssetAsync<T>(addressKey).ToUniTask();
            
            return resultObject;
        }

        public async UniTask<GameObject> CreateGameObject(string address, Transform parent = null)
        {
            GameObject resultObject = await Addressables.InstantiateAsync(address, parent);
            
            _container.InjectGameObject(resultObject);
            
            return resultObject;
        }
    }
}