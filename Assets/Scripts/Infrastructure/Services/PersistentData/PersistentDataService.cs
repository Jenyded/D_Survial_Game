using _Project.Scripts.Infrastructure.Services.PersistentData;

namespace _Project.Code.Infrastructure
{
    public class PersistentDataService : IPersistentDataService
    {
        public PlayerProgress Progress { get; set; }
        public PlayerOptions Options { get; set; }
    }
}