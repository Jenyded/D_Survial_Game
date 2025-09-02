using Configs;
using Cysharp.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IConfigService
    {
        UniTask Load();
        CharacterConfig ForCharacter(CharacterId id);
        EnemyConfig ForEnemy(EnemyId id);
        UIConfig ForUI();
    }
}