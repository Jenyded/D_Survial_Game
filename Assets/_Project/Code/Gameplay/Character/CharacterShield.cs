using System;
using _Project.Scripts.Gameplay;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Character.Status;
using Configs;
using Sirenix.OdinInspector;
using UnityEngine;

public class CharacterShield : MonoBehaviour
{
    public event Action<float> ShieldChanged;

    public float CurrentShield
    {
        get => _currentShield;
        private set => _currentShield = Mathf.Clamp(value, 0, MaxShield);
    }

    public float MaxShield { get; private set; }

    private float _currentShield;
        
    public void Construct(CharacterStatus characterStatus)
    {
        MaxShield = characterStatus.CurrentStatus.GetStatValue(StatId.Armor);
        CurrentShield = MaxShield;
    }
        
    [Button]
    public void TakeDamage(float value)
    {
        CurrentShield -= value;
        ShieldChanged?.Invoke(CurrentShield);
    }

    /*public void TakeHeal(float value)
    {
        CurrentShield += value;
        ShieldChanged?.Invoke(CurrentShield);
    }*/

    public void Restore()
    {
        CurrentShield = MaxShield;
        ShieldChanged?.Invoke(CurrentShield);
    }
}
