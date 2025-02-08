using System;
using Core.Character;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterDeath : MonoBehaviour
    {
        public event Action Died;
        
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterHealth _health;
        [SerializeField] private CharacterAnimator _animator;
        private bool _isDead;
        
        private void Awake()
        {
            _health.HealthChanged += TryDie;
        }

        private void TryDie(float health)
        {
            if (health > 0)
            {
                _isDead = false;
                return;
            }

            _isDead = true;

            _movement.enabled = false;
            _animator.PlayDeath();
            
            Died?.Invoke();
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= TryDie;
        }

    }
}