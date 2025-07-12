using _Project.Scripts.Infrastructure.Services.PersistentData;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService 
    {
        PlayerOptions LoadOptions();
        PlayerProgress Load();
        void Save();
    }
}