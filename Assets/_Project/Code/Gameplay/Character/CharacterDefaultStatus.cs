using System.Collections.Generic;
using System.Linq;
using Configs;

namespace Core.Character
{
    public class CharacterDefaultStatus : StatusEffect
    {
        private readonly Dictionary<StatId, Stat> _stats;
        private readonly CharacterConfig _config;

        public CharacterDefaultStatus(CharacterConfig config, string id) : base(id)
        {
            _stats = config.Stats.ToDictionary(x => x.Id);
            _config = config;
        }

        public override StatusEffect CloneWith(StatusEffect statusEffect)
        {
            return new CharacterDefaultStatus(_config, Id);
        }

        public override float GetStatValue(StatId statId) => _stats[statId].DefaultValue;
    }
}