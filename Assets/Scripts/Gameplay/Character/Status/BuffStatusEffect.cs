using System.Collections.Generic;
using Configs;

namespace Core.Character
{
    public class BuffStatusEffect : StatusEffectDecorator
    {
        private readonly Dictionary<StatId, BuffModifier> _modifiers;

        public BuffStatusEffect(StatusEffect statusEffect, Dictionary<StatId, BuffModifier> modifiers, string id) : base(statusEffect, id) 
        {
            _modifiers = modifiers;
        }

        public override float GetStatValue(StatId statId)
        {
            if (_modifiers.TryGetValue(statId, out var modifier))    
            {
                return modifier.MergeWith(_statusEffect.GetStatValue(statId));
            }

            return _statusEffect.GetStatValue(statId);
        }

        public override StatusEffect CloneWith(StatusEffect statusEffect)
        {
            return new BuffStatusEffect(statusEffect, _modifiers, Id);
        }

    }
}