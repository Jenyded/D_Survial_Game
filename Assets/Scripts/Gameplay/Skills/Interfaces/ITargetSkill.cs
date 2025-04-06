using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills.Interfaces
{
    public interface ITargetSkill : ISkill
    {
        bool TryUse(Transform target);
    }
}