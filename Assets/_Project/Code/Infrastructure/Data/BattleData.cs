using System;
using UniRx;

namespace _Project.Scripts.Infrastructure.Data
{
    [Serializable]
    public class BattleData
    {
        public ReactiveProperty<int> EnemyKilled;
    }
}