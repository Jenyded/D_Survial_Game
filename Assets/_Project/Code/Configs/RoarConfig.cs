using System.Collections.Generic;
using Configs;
using UnityEngine;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Skills/Druid/RoarSkill")]
    public class RoarConfig : SkillConfig
    {
        public BuffConfig DamageBuff;
        public BuffConfig EnemyDebuff;
    }
}