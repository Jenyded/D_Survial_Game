using UnityEngine;
using Zenject;

// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace _Project.Scripts.Infrastructure.Installers
{
    public class BattleInstaller : MonoInstaller
    {
        [SerializeField] private BattleCamera _battleCamera;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_battleCamera).AsSingle();
        }
    }
}