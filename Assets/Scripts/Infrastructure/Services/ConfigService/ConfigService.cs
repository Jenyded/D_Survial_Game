using System.Collections.Generic;
using System.Linq;
using Configs;
using Cysharp.Threading.Tasks;
using Services.Interfaces;
using UnityEngine.AddressableAssets;

namespace Services
{
    public class ConfigService : IConfigService
    {
        private const string CharacterKey = "CharacterConfig";
        private const string EnemyKey = "EnemyConfig";
        private const string UIKey = "UIConfig";

        private List<CharacterConfig> _characterConfigs = new();
        private List<EnemyConfig> _enemyConfigs = new();
        private UIConfig _uiConfig;
        
        public async UniTask Load()
        {
            var characterConfigsOperation = Addressables.LoadAssetsAsync<CharacterConfig>(CharacterKey, _ => { });
            var enemyConfigsOperation = Addressables.LoadAssetsAsync<EnemyConfig>(EnemyKey, _ => { });
            var uiConfigOperation = Addressables.LoadAssetAsync<UIConfig>(UIKey);

            await UniTask.WhenAll(
                characterConfigsOperation.ToUniTask(), 
                enemyConfigsOperation.ToUniTask(),
                uiConfigOperation.ToUniTask()
            );

            _characterConfigs = characterConfigsOperation.Result.ToList();
            _enemyConfigs = enemyConfigsOperation.Result.ToList();
            _uiConfig = uiConfigOperation.Result;
        }

        public CharacterConfig ForCharacter(CharacterId id) => _characterConfigs.FirstOrDefault(x => x.Id == id);
        public EnemyConfig ForEnemy(EnemyId id) => _enemyConfigs.FirstOrDefault(x => x.Id == id);

        public UIConfig ForUI() => _uiConfig;
    }
}