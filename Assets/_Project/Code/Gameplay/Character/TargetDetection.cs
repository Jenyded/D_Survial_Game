using System.Collections.Generic;
using _Project.Scripts.Gameplay.Character;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    public IReadOnlyList<Transform> EnemyTargets => _enemyTargets;

    [SerializeField] private TriggerObserver _directTrigger;
    [SerializeField] private TriggerObserver _areaTrigger;
    [SerializeField] private CharacterMovement _movement;
    [SerializeField] private GameObject _directRange;
    [SerializeField] private GameObject _areaRange;
    [SerializeField] private float _rotationOffset;
    private readonly List<Transform> _enemyTargets = new();

    public void Initialize()
    {
        _directTrigger.Entered += TryDetectEnemy;
        _directTrigger.Exited += TryRemoveEnemy;
        
        _areaTrigger.Entered += TryDetectEnemy;
        _areaTrigger.Exited += TryRemoveEnemy;
    }

    private void OnDestroy()
    {
        _directTrigger.Entered -= TryDetectEnemy;
        _directTrigger.Exited -= TryRemoveEnemy;
        
        _areaTrigger.Entered -= TryDetectEnemy;
        _areaTrigger.Exited -= TryRemoveEnemy;
    }

    private void TryDetectEnemy(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(WorldLayers.EnemyLayer) &&
            other.TryGetComponent(out IHealth health))
        {
            if (_enemyTargets.Contains(other.transform))
                return;
            
            _enemyTargets.Add(other.transform);
        }
    }

    private void TryRemoveEnemy(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(WorldLayers.EnemyLayer) && other.TryGetComponent(out IHealth health))
            _enemyTargets.Remove(other.transform);
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _movement.Velocity;

        float angleRadian = Mathf.Atan2(velocity.y, velocity.x);
        float angleDegrees = angleRadian * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, angleDegrees + _rotationOffset);
        _directRange.SetActive(velocity.sqrMagnitude > 0f);
        _areaRange.SetActive(velocity.sqrMagnitude <= 0f);
    }
}
