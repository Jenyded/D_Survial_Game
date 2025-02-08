using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterRevive : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _movement;
        [SerializeField] private CharacterHealth _health;
        [SerializeField] private CharacterAnimator _animator;
        [SerializeField] private CharacterDeath _death;
        
        public void Revive()
        {
            transform.position = Vector3.zero;
            
            _health.Restore();
            _animator.ResetAll();
            _movement.enabled = true;
        }
    }
}