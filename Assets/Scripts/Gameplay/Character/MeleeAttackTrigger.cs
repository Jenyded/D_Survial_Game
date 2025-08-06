using _Project.Scripts.Gameplay.Character;
using UnityEngine;

public class MeleeAttackTrigger : MonoBehaviour
{
    public bool IsAttacking
    {
        get => _isAttacking;
        set 
        { 
            _isAttacking = value; 
            _characterAnimator.SwitchHands(!_isAttacking);
            _characterAttack.SwitchHands(_isAttacking);
        }
    }

    [SerializeField] private TargetDetection _targetDetection;
    [SerializeField] private CharacterAttack _characterAttack;
    [SerializeField] private CharacterAnimator _characterAnimator;

    private bool _isAttacking;

    private void Awake()
    {
        IsAttacking = false;
    }
    
    private async void Update()
    {
        if (IsAttacking)
            return;
        
        if (_targetDetection.EnemyTargets.Count > 0)
        {
            IsAttacking = true;
            await _characterAttack.BaseAttack(_targetDetection.EnemyTargets);
            IsAttacking = false;
        }
    }
}