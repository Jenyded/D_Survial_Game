using System.Collections.Generic;
using _Project.Scripts.Configs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/Character")]
    public class CharacterConfig : ScriptableObject
    {
        [Header("Id"), Space(5f)]
        public CharacterId Id;
        
        [Header("Stats"), Space(5f)] 
        public List<Stat> Stats;

        [Header("Skills"), Space(5f)] 
        public List<SkillConfig> Skills;
        public SkillConfig JoystickSkill;
        public SkillConfig SwipeSkill;

        [Header("Other"), Space(5f)]
        public AssetReference Prefab;

    }

    public enum CharacterId
    {
        Savage = 0,
    }
}