using UnityEngine;
using Configs;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Skills/GroundSlamSkill")]
    public class GroundSlamConfig : SkillConfig
    {
        public float DamageMultiplier = 2f;
        public float Radius = 15f;
    }
} 