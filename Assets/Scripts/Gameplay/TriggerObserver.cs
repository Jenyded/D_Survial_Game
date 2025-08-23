using System;
using UnityEngine;

public class TriggerObserver : MonoBehaviour
{
    public event Action<Collider2D> Entered;
    public event Action<Collider2D> Exited;
    public event Action<Collider2D> Staying;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entered?.Invoke(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Staying?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Exited?.Invoke(other);
    }
}