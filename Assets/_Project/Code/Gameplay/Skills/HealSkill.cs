using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    public class HealSkill : IHealingSkill
    {
        public float HealAmount { get; private set; }

        public HealSkill(HealConfig config)
        {
            HealAmount = config.DefaultHeal;
        }
        
        public bool TryUse(GameObject character, Transform target)
        {
            IHealth health = character.GetComponent<IHealth>();
            if (health.CurrentHealth < health.MaxHealth)
            {
                health.TakeHeal(HealAmount);
                return true;
            }

            return false;
        }

        public void Cancel()
        {
            throw new System.NotImplementedException();
        }
    }
}
