using UnityEngine;
using Configs;

namespace _Project.Scripts.Configs
{
    [CreateAssetMenu(menuName = "Configs/Skills/ShredSkill")]
    public class ShredConfig : SkillConfig
    {
        public float DamagePerHit = 0.5f; // 50%
        public int HitCount = 5;
        public float AreaWidth = 2f;
        public float AreaLength = 8f;
        public float ProjectileSpeed = 15f;
        public GameObject ProjectilePrefab;
    }
} 