using System.Collections.Generic;
using System.Linq;
using Configs;

namespace _Project.Scripts.Gameplay.Enemy
{
    public class EnemyDefaultStatus : StatusEffect
    {
        private readonly Dictionary<StatId, Stat> _stats;
        
        public EnemyDefaultStatus(EnemyConfig enemyConfig, string id) : base(id)
        {
            _stats = enemyConfig.Stats.ToDictionary(x => x.Id);
        }

        public override float GetStatValue(StatId statId)
        {
            throw new System.NotImplementedException();
        }

        public override StatusEffect CloneWith(StatusEffect statusEffect)
        {
            throw new System.NotImplementedException();
        }
    }
}