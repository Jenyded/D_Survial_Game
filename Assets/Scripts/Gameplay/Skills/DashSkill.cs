using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    public class DashSkill : IDirectionSkill
    {
        private readonly CharacterMovement _movement;

        public DashSkill(DashConfig config)
        {
            
        }

        public void Use(GameObject character, Vector2 direction)
        {
            character.GetComponent<CharacterMovement>().PushTo(direction);
        }
    }
}