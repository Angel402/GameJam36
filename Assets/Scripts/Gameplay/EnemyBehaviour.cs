using System;
using UnityEngine;

namespace Gameplay
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        public Action OnDeath;
        [SerializeField] protected int health;

        public abstract void Attack();
        public abstract void GetDamage();
        public abstract void Death();
    }
}