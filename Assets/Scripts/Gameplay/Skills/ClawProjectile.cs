using _Project.Scripts.Gameplay.Character;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    public class ClawProjectile : MonoBehaviour
    {
        private float _damage;
        private float _speed;
        private bool _launched;

        public void Launch(float damage, float speed)
        {
            _damage = damage;
            _speed = speed;
            _launched = true;
            Destroy(gameObject, 4f);
        }

        private void Update()
        {
            if (!_launched) return;

            Vector3 move = transform.right * _speed * Time.deltaTime;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, move.magnitude);

            if (hit.collider != null)
            {
                var health = hit.collider.GetComponent<Health>();
                if (health != null)
                {
                    transform.position = hit.point;
                    health.TakeDamage(_damage);
                    Destroy(gameObject);
                    return;
                }
            }

            transform.position += move;
        }
    }
}