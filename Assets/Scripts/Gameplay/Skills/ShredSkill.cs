using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character.Status;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using UnityEngine;
using System.Collections;
using _Project.Scripts.Gameplay.Character;
using Configs;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace _Project.Scripts.Gameplay.Skills
{
    public class ShredSkill : INonTargetSkill
    {
        private readonly ShredConfig _config;
        private readonly Transform _characterTransform;
        private CancellationTokenSource _cts;

        public ShredSkill(ShredConfig config, Transform characterTransform)
        {
            _config = config;
            _characterTransform = characterTransform;
        }

        public void Use(GameObject character)
        {
            if (_cts != null) 
                return;
                
            _cts = new CancellationTokenSource();
            SpawnProjectilesLoop(character, _cts.Token).Forget();
        }

        private async UniTaskVoid SpawnProjectilesLoop(GameObject character, CancellationToken token)
        {
            BaseStatus status = character.GetComponent<StatusHolder>().StatusInstance;
            int count = _config.HitCount;
            float spreadAngle = 40f;
            float startAngle = -spreadAngle / 2f;
            while (!token.IsCancellationRequested)
            {
                float damage = status.CurrentStatus.GetStatValue(StatId.Power) * _config.DamagePerHit;
                Vector2 direction = Joystick.Direction;
                if (direction == Vector2.zero)
                {
                    direction = _characterTransform.right;
                }
                for (int i = 0; i < count; i++)
                {
                    float angle = startAngle + spreadAngle * i / (count - 1);
                    Vector2 spreadDir = Quaternion.Euler(0, 0, angle) * direction;
                    SpawnProjectile(spreadDir, damage);
                }
                await UniTask.Delay(80, cancellationToken: token); // 0.08 сек между "волнами"
            }
        }

        private void SpawnProjectile(Vector2 direction, float damage)
        {
            var projectile = Object.Instantiate(_config.ProjectilePrefab, _characterTransform.position, Quaternion.identity);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(0, 0, angle);
            var claw = projectile.GetComponent<ClawProjectile>();
            claw.Launch(damage, _config.ProjectileSpeed);
        }

        private void ShowArea(Vector2 direction)
        {
            // Здесь можно реализовать подсветку зоны поражения (например, через LineRenderer или временный спрайт)
        }

        public void Cancel()
        {
            _cts?.Cancel();
            _cts = null;
        }
    }
} 