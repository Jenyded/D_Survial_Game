using System;
using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Skills;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using UnityEngine;

public class UseJoystickSkill : MonoBehaviour
{
    [SerializeField] private Cooldown _cooldown;
    private SkillConfig _skill;
    private SkillExecutor _skillExecutor;

    public void Construct(SkillExecutor skillExecutor, SkillConfig skillConfig)
    {
        _skillExecutor = skillExecutor;
        _skill = skillConfig;
    }
    
    private void OnEnable()
    {
        Joystick.Clicked += UseSkill;
    }

    private void OnDisable()
    {
        Joystick.Clicked -= UseSkill;
    }

    private void UseSkill()
    {
        _skillExecutor.Execute(_skill, null);
        if (_cooldown.CurrentTime <= 0f)
        {
            bool useSuccess = _skill;
            if (useSuccess)
                _cooldown.Launch();
        }
    }
}