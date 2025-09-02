using System.Collections.Generic;
using _Project.Scripts.Gameplay.Skills;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Skill")]
    public class SkillConfig : ScriptableObject
    {
        [Header("Info"), Space(5f)] 
        public string Name;
        public Sprite Icon;
        public string Animation;
        public float Cooldown;
        public float CastTime;
        public GameObject VfxPrefab;
        
        
        [Header("Effects"), Space(5f)]
        [SerializeReference] public List<SkillEffect> Effects;

    }
}