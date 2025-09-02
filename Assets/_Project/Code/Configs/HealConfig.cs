using Configs;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Skills/HealSkill")]
    public class HealConfig : SkillConfig
    {
        public float DefaultHeal;
    }
}