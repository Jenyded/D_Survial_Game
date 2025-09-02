namespace _Project.Scripts.Infrastructure.Services.PersistentData
{
    public interface IPersistentDataService
    {
        public PlayerProgress Progress { get; set; }
        public PlayerOptions Options { get; set; }
    }
}