using _Project.Scripts.Infrastructure.Services.PersistentData;

public interface IProgressWriter
{
    void WriteProgress(PlayerProgress progress);
}