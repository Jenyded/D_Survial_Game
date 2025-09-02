using System;
using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class SkillExecutor : MonoBehaviour
{
    private GameObject _character;
    private SkillConfig _currentSkill;
    private CharacterAnimator _animator;

    public void Construct(GameObject character)
    {
        _character = character;
    }
    
    private void Awake()
    {
        _animator = GetComponent<CharacterAnimator>();
    }

    public void Execute(SkillConfig skill, GameObject target)
    {
        _currentSkill = skill;
        
        if (skill.Animation != string.Empty)
            _animator.PlayCustomOneShot(skill.Animation);
        
        UniTask.WaitForSeconds(skill.CastTime).ContinueWith(() =>
        {
            if (_currentSkill.VfxPrefab != null)
               SpawnVfx(target);
            else
                _currentSkill.Effects.ForEach(x => x.Use(_character, target));
        });
    }

    private void SpawnVfx(GameObject target)
    {
        
    }

    public void Execute(SkillConfig skill, Vector2 direction)
    {
        GameObject target = new GameObject();
        target.transform.position = new Vector2(_character.transform.position.x, _character.transform.position.y) - direction; 
        
        Execute(skill, target);
    }
}