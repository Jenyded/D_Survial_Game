using System.Threading.Tasks;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        UniTask<GameObject> CreateCharacter(CharacterId id);
        UniTask CreateHud();
        UniTask<GameObject> CreateEnemy(EnemyId test);
    }
}