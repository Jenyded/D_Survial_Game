using UnityEngine;
using _Project.Scripts.Gameplay.Character;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _healthBarFill;
    private IHealth _health;
    
    public void Construct(IHealth health)
    {
        _health = health;
        _health.HealthChanged += UpdateHealthBar;
        UpdateHealthBar(_health.CurrentHealth);
    }

    private void UpdateHealthBar(float currentHealth)
    {
        float healthPercentage = Mathf.Clamp01(currentHealth / _health.MaxHealth);
        _healthBarFill.localScale = new Vector3(healthPercentage, _healthBarFill.localScale.y, _healthBarFill.localScale.z);
    }

    private void OnDestroy()
    {
        if (_health != null)
        {
            _health.HealthChanged -= UpdateHealthBar;
        }
    }
}