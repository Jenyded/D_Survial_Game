using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Character.Status;
using Configs;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    private IHealth _health;
    private BaseStatus _status;
    
    public void Construct(BaseStatus status)
    {
        _status = status;
        _health = GetComponent<IHealth>();
    }

    private void Update()
    {
        if (_health == null)
            return;
        
        if (_health.CurrentHealth < _health.MaxHealth)
        {
            float healthRegenPerSecond = _status.CurrentStatus.GetStatValue(StatId.HealthRegen);
            _health.TakeHeal(healthRegenPerSecond * Time.deltaTime);
        }
    }
}
