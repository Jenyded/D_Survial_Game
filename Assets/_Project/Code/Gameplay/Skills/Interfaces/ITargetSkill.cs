using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills.Interfaces
{
    public interface ITargetSkill : ISkill
    {
        bool TryUse(GameObject character, Transform target);
    }
}