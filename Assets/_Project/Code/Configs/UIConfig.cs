using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/UI")]
    public class UIConfig : ScriptableObject
    {
        [Header("LoadingScreen"), Space(5f)] 
        public AssetReference LoadingScreenPrefab;
        
        [Header("HUD"), Space(5f)] 
        public AssetReference HudPrefab;
        public AssetReference SkillButtonPrefab;
        
        [Header("Windows"), Space(5f)]
        public List<AssetReference> WindowPrefabs;
    }
}