using UnityEngine;

namespace _Project.Scripts.Configs
{
    public abstract class SkillConfig : ScriptableObject
    {
        [Header("UI"), Space(5f)] 
        public string Name;
        public Sprite Icon;
        
        [Header("Values"), Space(5f)]
        public float Cooldown;
    }
}