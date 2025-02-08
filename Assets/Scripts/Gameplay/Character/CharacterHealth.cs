using System;
using _Project.Scripts.Infrastructure.Services.PersistentData;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        public event Action<float> HealthChanged;

        public float CurrentHealth
        {
            get => _currentHealth;
            private set => _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
        }

        public float MaxHealth { get; private set; }

        private float _currentHealth;
        
        public void Construct(CharacterStatus characterStatus)
        {
            MaxHealth = characterStatus.Current.Health();
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