using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using _Project.Scripts.Gameplay.Enemy;
using Core.Character;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Gameplay.Character.Status;

namespace _Project.Scripts.Gameplay.Skills
{
    public class RoarSkill : INonTargetSkill
    {
        private readonly RoarConfig _config;
        private readonly StatusEffectFactory _statusEffectFactory;

        public RoarSkill(RoarConfig config, StatusEffectFactory statusEffectFactory)
        {
            _config = config;
            _statusEffectFactory = statusEffectFactory;
        }

        public void Use(GameObject character)
        {
            // 1. Радиус в world units (2/3 ширины экрана)
            float screenRadius = GetRoarRadius();
            Vector2 center = character.transform.position;

            // 2. Найти всех врагов в радиусе
            Collider2D[] hits = Physics2D.OverlapCircleAll(center, screenRadius);
            foreach (var hit in hits)
            {
                BaseStatus enemyStatus = hit.GetComponent<StatusHolder>().StatusInstance;
                _statusEffectFactory.CreateBuffEffectFor(enemyStatus, _config.EnemyDebuff);
            }

            BaseStatus characterStatus = character.GetComponent<StatusHolder>().StatusInstance;
            _statusEffectFactory.CreateBuffEffectFor(characterStatus, _config.DamageBuff);
        }

        private float GetRoarRadius()
        {
            // 2/3 ширины экрана в world units
            Camera cam = Camera.main;
            if (cam == null) return 5f; // fallback
            float screenWidth = Screen.width;
            Vector3 left = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
            Vector3 right = cam.ScreenToWorldPoint(new Vector3(screenWidth * 2f / 3f, 0, cam.nearClipPlane));
            float radius = Mathf.Abs(right.x - left.x);
            return radius;
        }

        public void Cancel()
        {
            throw new System.NotImplementedException();
        }
    }
}