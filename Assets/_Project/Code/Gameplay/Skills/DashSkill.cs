using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    public class DashSkill : IDirectionSkill
    {
        private readonly CharacterMovement _movement;
        private readonly float _distance;

        public DashSkill(DashConfig config)
        {
            _distance = config.Distance;
        }

        public void Use(GameObject character, Vector2 direction)
        {
            character.GetComponent<CharacterMovement>().PushTo(direction, _distance);
        }

        public void Cancel()
        {
            
        }
    }
}