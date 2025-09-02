using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Skills/Attack")]
    public class AttackConfig : SkillConfig
    {
        public float DamageMultiplier;
        public float Radius;
        public float BaseAnimationSpeed;
    }
}