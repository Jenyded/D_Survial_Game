using System;
using _Project.Scripts.Gameplay.Character.Status;
using Configs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action<float> HealthChanged;

        public float CurrentHealth
        {
            get => _currentHealth;
            private set => _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
        }

        public float MaxHealth { get; private set; }

        private float _currentHealth;
        
        public void Construct(BaseStatus status)
        {
            MaxHealth = status.CurrentStatus.GetStatValue(StatId.Health);
            CurrentHealth = MaxHealth;
        }
        
        [Button]
        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
            HealthChanged?.Invoke(CurrentHealth);
        }

        public void TakeHeal(float value)
        {
            CurrentHealth += value;
            HealthChanged?.Invoke(CurrentHealth);
        }

        public void Restore()
        {
            CurrentHealth = MaxHealth;
            HealthChanged?.Invoke(CurrentHealth);
        }
    }
}