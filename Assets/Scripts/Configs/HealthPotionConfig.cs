using Configs;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Skills/HealthPotion")]
    public class HealthPotionConfig : SkillConfig
    {
        public float DefaultHeal;
    }
}