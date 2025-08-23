using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Character.Status;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using Configs;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    public class GroundSlamSkill : INonTargetSkill
    {
        private readonly GroundSlamConfig _config;
        private readonly Transform _characterTransform;

        public GroundSlamSkill(GroundSlamConfig config, Transform characterTransform)
        {
            _config = config;
            _characterTransform = characterTransform;
        }

        public void Use(GameObject character)
        {
            BaseStatus status = character.GetComponent<StatusHolder>().StatusInstance;
            float radius = _config.Radius;
            
            Vector2 center = _characterTransform.position;
            float currentPower = status.CurrentStatus.GetStatValue(StatId.Power);
            float damage = currentPower * _config.DamageMultiplier;

            Collider2D[] hits = Physics2D.OverlapCircleAll(center, radius);
            foreach (var hit in hits)
            {
                var enemyHealth = hit.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }

        public void Cancel()
        {
            
        }
    }
}