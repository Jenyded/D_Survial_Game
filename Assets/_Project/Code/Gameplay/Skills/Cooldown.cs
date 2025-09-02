using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    public class Cooldown : MonoBehaviour
    {
        public float CurrentTime { get; private set; }
        public float DefaultTime { get; private set; }
        
        public void Construct(float defaultTime)
        {
            DefaultTime = defaultTime;
        }

        public void Launch()
        {
            CurrentTime = DefaultTime;
        }
        
        private void Update()
        {
            if (CurrentTime <= 0f)
                return;

            CurrentTime -= Time.deltaTime;
        }
    }
}