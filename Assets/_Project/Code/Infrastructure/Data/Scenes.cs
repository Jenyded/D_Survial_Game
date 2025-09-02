using UnityEngine;

namespace _Project.Scripts.Infrastructure.Data
{
    [CreateAssetMenu(fileName = "Scenes", menuName = "Configs/Infrastructure/Scenes")]
    public class Scenes : ScriptableObject
    {
        public string Bootstrap;
        public string Battle;
        public string Meta;
    }
}