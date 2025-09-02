using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills.Interfaces
{
    public interface INonTargetSkill : ISkill
    {
        void Use(GameObject character);
    }
}