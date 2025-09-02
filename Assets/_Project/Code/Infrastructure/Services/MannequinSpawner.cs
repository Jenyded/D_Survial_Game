using System;
using _Project.Scripts.Infrastructure.Factories;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.Services
{
    public class MannequinSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _mannequin;
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private async void Awake()
        {
            Vector3 position = _mannequin.transform.position;
            
            Destroy(_mannequin);

            await UniTask.Delay(TimeSpan.FromSeconds(0.2f), DelayType.DeltaTime);
            GameObject testEnemy = await _gameFactory.CreateEnemy(EnemyId.Test);
            testEnemy.transform.position = position;
        }
    }
}