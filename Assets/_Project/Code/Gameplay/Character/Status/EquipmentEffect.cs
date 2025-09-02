using Configs;

namespace Core.Character
{
    public class EquipmentEffect : StatusEffectDecorator
    {
        public EquipmentEffect(StatusEffect statusEffect, string id) : base(statusEffect, id){}

        public override StatusEffect CloneWith(StatusEffect statusEffect)
        {
            throw new System.NotImplementedException();
        }

        public override float GetStatValue(StatId statId)
        {
            throw new System.NotImplementedException();
        }
    }
}