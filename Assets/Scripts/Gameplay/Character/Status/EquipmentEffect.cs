namespace Core.Character
{
    public class EquipmentEffect : StatusEffectDecorator
    {
        public EquipmentEffect(StatusEffect statusEffect) : base(statusEffect){}

        public override float Power()
        {
            throw new System.NotImplementedException();
        }

        public override float Attack()
        {
            throw new System.NotImplementedException();
        }

        public override float ReducingCooldown()
        {
            throw new System.NotImplementedException();
        }

        public override float CriticalChance()
        {
            throw new System.NotImplementedException();
        }

        public override float CriticalDamage()
        {
            throw new System.NotImplementedException();
        }

        public override float Health()
        {
            throw new System.NotImplementedException();
        }

        public override float HealthRegen()
        {
            throw new System.NotImplementedException();
        }

        public override float Armor()
        {
            throw new System.NotImplementedException();
        }

        public override float Harmony()
        {
            throw new System.NotImplementedException();
        }

        public override float MoveSpeed()
        {
            throw new System.NotImplementedException();
        }
    }
}