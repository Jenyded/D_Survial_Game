using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterHit : MonoBehaviour
    {
        public List<IHealth> Hit(Vector3 position, float radius = 2f)
        {
            List<IHealth> enemyHealths = new();
            
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(position, radius, LayerMask.GetMask(WorldLayers.EnemyLayer));

            foreach (var enemyCollider in enemyColliders)
            {
                enemyHealths.Add(enemyCollider.GetComponent<IHealth>());
            }

            return enemyHealths;
        }
    }

    public interface IHealth
    {
        event Action<float> HealthChanged;
        
        float CurrentHealth { get; }
        float MaxHealth { get; }
        
        void TakeDamage(float value);
        void TakeHeal(float value);
    }
}