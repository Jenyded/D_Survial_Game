using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private CharacterHit _characterHit;
        private CharacterStatus _status;

        public void Construct(CharacterStatus status)
        {
            _status = status;
        }
        
        private void Attack()
        {
            List<IHealth> enemies = _characterHit.Hit(transform.position);
            enemies.ForEach(x => x.TakeDamage(_status.Current.Attack()));
        }
    }
}