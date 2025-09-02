using System;

namespace Configs
{
    [Serializable]
    public class Stat
    {
        public StatId Id;
        public float DefaultValue;
    }

    public enum StatId
    {
        AttackSpeed = 0,
        Armor = 1,
        CriticalChance = 2,
        CriticalDamage = 3,
        Harmony = 4,
        Health = 5,
        HealthRegen = 6,
        MoveSpeed = 7,
        Power = 8,
        ReducingCooldown = 9
    }
}