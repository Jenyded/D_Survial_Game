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
            //throw new System.NotImplementedException(); строчка для дальнейшей логики, ниже весь метод потом удаляется
            if (_stats.TryGetValue(statId, out var stat))
                return stat.DefaultValue;

            UnityEngine.Debug.LogWarning($"Stat {statId} not found in EnemyDefaultStatus.");
            return 0f;
        }

        public override StatusEffect CloneWith(StatusEffect statusEffect)
        {
            throw new System.NotImplementedException();
        }
    }
}