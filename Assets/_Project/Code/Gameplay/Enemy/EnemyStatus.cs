using _Project.Scripts.Gameplay;
using _Project.Scripts.Gameplay.Enemy;
using Configs;
using Sirenix.Reflection.Editor;

namespace _Project.Scripts.Gameplay.Character.Status
{
    public class EnemyStatus : BaseStatus
    {
        private string Id = "enemyMainStatus";
        private readonly EnemyConfig _config;
        
        public EnemyStatus(EnemyConfig config) => _config = config;

        public override void AddStatusEffect<T>(StatusEffect effect)
        {
            throw new System.NotImplementedException();
        }

        public override void RefreshStatus()
        {
            CurrentStatus = new EnemyDefaultStatus(_config, Id);
        }

        public override void RemoveStatusEffect<T>(StatusEffect effect)
        {
            throw new System.NotImplementedException();
        }
    }
}