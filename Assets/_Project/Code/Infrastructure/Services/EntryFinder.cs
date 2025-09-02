using UnityEngine;

namespace _Project.Scripts.Infrastructure.Services
{
    public class EntryFinder : MonoBehaviour
    {
        public T FindEntry<T>() where T: MonoBehaviour, IEntryPoint
        {
            return FindObjectOfType<T>();
        }
    }

    public interface IEntryPoint
    {
        
    }
}