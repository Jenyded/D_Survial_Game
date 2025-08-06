using _Project.Scripts.Gameplay.Character.Status;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class StatusHolder : MonoBehaviour
    {
        public BaseStatus StatusInstance { get; private set; }

        public void Construct(BaseStatus status)
        {
            StatusInstance = status;
        }
    }
}