namespace Core.Character
{
    public class BuffEffect : StatusEffectDecorator
    {
        public BuffEffect(StatusEffect statusEffect) : base(statusEffect) { }

        public override float Power() => _statusEffect.Power();

        public override float Attack() => _statusEffect.Attack();

        public override float ReducingCooldown() => _statusEffect.ReducingCooldown();

        public override float CriticalChance() => _statusEffect.CriticalChance();
        public override float CriticalDamage() => _statusEffect.CriticalDamage();

        public override float Health() => _statusEffect.Health();

        public override float HealthRegen() => _statusEffect.HealthRegen();

        public override float Armor() => _statusEffect.Armor();

        public override float Harmony() => _statusEffect.Harmony();

        public override float MoveSpeed() => _statusEffect.MoveSpeed();
    }
}