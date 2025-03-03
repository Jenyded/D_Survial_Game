using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    public class HealthPotionSkill : IHealingSkill
    {
        public float HealAmount { get; private set; }

        public HealthPotionSkill(HealthPotionConfig config)
        {
            HealAmount = config.DefaultHeal;
        }
        
        public bool TryUse(Transform target)
        {
            IHealth health = target.GetComponent<IHealth>();
            if (health.CurrentHealth < health.MaxHealth)
            {
                health.TakeHeal(HealAmount);
                return true;
            }

            return false;
        }
    }
}