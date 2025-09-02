using UnityEngine;
using _Project.Scripts.Gameplay.Character;

public class ShieldBar : MonoBehaviour
{
    [SerializeField] private Transform _shieldBarFill;
    [SerializeField] private CharacterShield _characterShield;
    
    public void Construct(CharacterShield characterShield)
    {
        _characterShield = characterShield;
        _characterShield.ShieldChanged += UpdateShieldBar;
        UpdateShieldBar(_characterShield.CurrentShield);
    }

    private void UpdateShieldBar(float currentShield)
    {
        float shieldPercentage = Mathf.Clamp01(currentShield / _characterShield.MaxShield);
        _shieldBarFill.localScale = new Vector3(shieldPercentage, _shieldBarFill.localScale.y, _shieldBarFill.localScale.z);
    }

    private void OnDestroy()
    {
        if (_characterShield != null)
        {
            _characterShield.ShieldChanged -= UpdateShieldBar;
        }
    }
}