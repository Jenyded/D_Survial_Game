using _Project.Scripts.Infrastructure.Services.Input;
using UnityEngine;
using Configs;
using _Project.Scripts.Gameplay.Character.Status;

namespace _Project.Scripts.Gameplay.Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        public Vector2 Velocity => _rigidbody.linearVelocity;
        
        private Rigidbody2D _rigidbody;
        private CharacterStatus _status;
        private IInputService _inputService;
        private Vector2 _pushVelocity;
        private float _pushDamping;

        public void Construct(CharacterStatus status, IInputService inputService)
        {
            _status = status;
            _inputService = inputService;
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        
        private void Move(Vector2 direction)
        {
            if (direction.x != 0)
                transform.localScale = new Vector3(direction.x > 0 ? 1f : -1f, 1, 1);
            
            _rigidbody.linearVelocity = direction * (_status.CurrentStatus.GetStatValue(StatId.MoveSpeed) * Time.deltaTime) + _pushVelocity;
            DampPush();
        }

        public void PushTo(Vector2 direction, float distance)
        {
            _pushDamping = 0f;
            _pushVelocity = direction * (_status.CurrentStatus.GetStatValue(StatId.MoveSpeed) * distance);
        }

        private void FixedUpdate()
        {
            if (_inputService == null)
                return;
            
            Move(_inputService.GetAxis());
        }

        private void DampPush()
        {
            if (_pushDamping >= 1f)
            {
                _pushVelocity = Vector2.zero;
                return;
            }
            
            _pushVelocity = Vector2.LerpUnclamped(_pushVelocity, Vector2.zero, _pushDamping);
            _pushDamping += Time.deltaTime;
        }
    }
}