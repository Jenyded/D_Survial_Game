using _Project.Scripts.Gameplay.Skills;
using UnityEngine;
using UnityEngine.UI;

public class CooldownIndicator : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Cooldown _cooldown;

    private void Update()
    {
        _image.fillAmount = 1f - _cooldown.CurrentTime / _cooldown.DefaultTime;
    }
}