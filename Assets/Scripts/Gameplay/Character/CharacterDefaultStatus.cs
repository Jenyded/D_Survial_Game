using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Core.Character
{
    public class CharacterDefaultStatus : StatusEffect
    {
        private readonly Dictionary<StatId, Stat> _stats;
    
        public CharacterDefaultStatus(CharacterConfig config)
        {
            _stats = config.Stats.ToDictionary(x => x.Id);
        }
    
        public override float Power() => _stats[StatId.Power].DefaultValue;

        public override float Attack() => _stats[StatId.AttackSpeed].DefaultValue;

        public override float ReducingCooldown() => _stats[StatId.ReducingCooldown].DefaultValue;

        public override float CriticalChance() => _stats[StatId.CriticalChance].DefaultValue;
    
        public override float CriticalDamage() => _stats[StatId.CriticalDamage].DefaultValue;

        public override float Health() => _stats[StatId.Health].DefaultValue;

        public override float HealthRegen() => _stats[StatId.HealthRegen].DefaultValue;

        public override float Armor() => _stats[StatId.Armor].DefaultValue;

        public override float Harmony() => _stats[StatId.Harmony].DefaultValue;

        public override float MoveSpeed() => _stats[StatId.MoveSpeed].DefaultValue;
    }
}