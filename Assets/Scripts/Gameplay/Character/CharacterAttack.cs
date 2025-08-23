using System;
using System.Collections.Generic;
using System.Threading;
using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character.Status;
using Configs;
using Cysharp.Threading.Tasks;
using DG.Tweening;
//using Sirenix.Utilities;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private CharacterHit _characterHit;
        [SerializeField] private List<Transform> _hands;
        [SerializeField] private List<Transform> _handPivots;
        private Vector3[] _defaultLocalPositions;
        private CharacterStatus _status;
        private List<AttackConfig> _baseAttacks;
        private int _currentAttackIndex;
        private CancellationTokenSource _attackTokenSource;
        
        public void Construct(CharacterStatus status, List<AttackConfig> baseAttacks)
        {
            _baseAttacks = baseAttacks;
            _status = status;
            _defaultLocalPositions = new Vector3[_hands.Count];
        }

        public void SwitchHands(bool isActive)
        {
            _hands.ForEach(x => x.gameObject.SetActive(isActive));
        }

        public async UniTask BaseAttack(IReadOnlyList<Transform> targets)
        {
            int handIndex = _currentAttackIndex % 2;

            Transform hand = _hands[handIndex];
            Transform handPivot = _handPivots[handIndex];
            
            if (_defaultLocalPositions[handIndex] == default)
                _defaultLocalPositions[handIndex] = hand.localPosition;

            float duration = _baseAttacks[_currentAttackIndex].BaseAnimationSpeed;

            float moveDistance = 2.6f; // фиксированная дистанция, можешь вынести в переменные

            Vector3 direction = (targets[0].position - hand.position).normalized;
            Vector3 targetPosition = hand.position + direction * moveDistance;
            
            hand.GetComponent<TriggerObserver>().Entered += DamageTarget;

            Tween handMove = hand.DOMove(targetPosition, duration).SetDelay(duration / 2f).SetEase(Ease.InOutBack);
            Tween handRotate = handPivot.DoRotateToward(targets[0], duration, transform.localScale.x < 0).SetEase(Ease.InOutBack);
            
            await UniTask.Delay(TimeSpan.FromSeconds(duration + duration / 2)).AttachExternalCancellation(new CancellationTokenSource().Token);
            
            hand.GetComponent<TriggerObserver>().Entered -= DamageTarget;

            handPivot.DOLocalRotate(Vector3.zero, duration);
            hand.DOLocalMove(_defaultLocalPositions[handIndex], duration);


            _attackTokenSource = new();

            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_baseAttacks[_currentAttackIndex].Cooldown)).AttachExternalCancellation(_attackTokenSource.Token);
            }
            catch (Exception e)
            {
                CancelAttack();
            }
            
            _currentAttackIndex++;

            if (_currentAttackIndex >= _baseAttacks.Count)
                _currentAttackIndex = 0;
        }

        private void DamageTarget(Collider2D target)
        {
            if (target.gameObject.layer == LayerMask.NameToLayer(WorldLayers.EnemyLayer) && target.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(_status.CurrentStatus.GetStatValue(StatId.Power) * _baseAttacks[_currentAttackIndex].DamageMultiplier);
            }
        }

        private void AttackToPosition()
        {
            List<IHealth> enemies = _characterHit.Hit(transform.position);
            enemies.ForEach(x => x.TakeDamage(_status.CurrentStatus.GetStatValue(StatId.Power)));
        }

        private void CancelAttack()
        {
            _attackTokenSource?.Cancel();
            _attackTokenSource?.Dispose();
            _attackTokenSource = null;
            
            Debug.Log("Attack canceled!");
        }
    }
}