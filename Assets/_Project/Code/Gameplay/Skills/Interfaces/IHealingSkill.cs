namespace _Project.Scripts.Gameplay.Skills.Interfaces
{
    public interface IHealingSkill : ITargetSkill
    {
        public float HealAmount { get; }
    }
}