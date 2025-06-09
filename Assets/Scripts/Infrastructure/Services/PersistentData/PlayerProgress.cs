using System;
using _Project.Scripts.Infrastructure.Data;

namespace _Project.Scripts.Infrastructure.Services.PersistentData
{
    [Serializable]
    public class PlayerProgress
    {
        public string SaveVersion;
        public BattleData BattleData;
    }
}