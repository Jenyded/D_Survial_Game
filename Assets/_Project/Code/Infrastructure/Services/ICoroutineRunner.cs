using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Services
{
    public interface ICoroutineRunner
    {
        Coroutine Run(IEnumerator enumerator);
        void Stop(Coroutine coroutine);
    }
}