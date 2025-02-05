using _Project.Scripts.Infrastructure.Services.Input;
using Core.Character;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterMovement _movement;
        private IInputService _inputService;
        
        private readonly int Move = Animator.StringToHash("Move");
        private readonly int Death = Animator.StringToHash("Death");
        
        
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Update()
        {
            if (_inputService == null)
                return;
            
            _animator.SetFloat(Move, _inputService.GetAxis().magnitude);
        }

        public void PlayDeath()
        {
            _animator.SetBool(Death, true);
        }

        public void ResetAll()
        {
            _animator.Rebind();
        }
    }
}