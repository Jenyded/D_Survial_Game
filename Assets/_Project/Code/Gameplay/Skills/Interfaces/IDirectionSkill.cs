using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills.Interfaces
{
    public interface IDirectionSkill : ISkill
    {
        void Use(GameObject character, Vector2 direction);
    }
}