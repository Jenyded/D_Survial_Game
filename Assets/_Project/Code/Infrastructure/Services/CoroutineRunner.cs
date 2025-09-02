using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Services
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        
        public Coroutine Run(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }

        public void Stop(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}