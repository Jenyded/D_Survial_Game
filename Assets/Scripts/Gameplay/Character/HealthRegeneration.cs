using _Project.Scripts.Gameplay.Character;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    private IHealth _health;
    private CharacterStatus _status;
    
    public void Construct(CharacterStatus status)
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
            float healthRegenPerSecond = _status.Current.HealthRegen();
            _health.TakeHeal(healthRegenPerSecond * Time.deltaTime);
        }
    }
}