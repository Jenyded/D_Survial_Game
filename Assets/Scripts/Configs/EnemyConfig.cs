using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [Header("Id"), Space(5f)]
        public EnemyId Id;

        [Header("Stats"), Space(5f)] 
        public List<Stat> Stats;

        [Header("Other"), Space(5f)]
        public AssetReference Prefab;
    }
}