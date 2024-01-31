using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private int health;

        public abstract void Attack();
        public abstract void GetDamage();
    }

    public class EnemiesSystem : MonoBehaviour
    {
        [Serializable]
        public class Enemy
        {
            public EnemyBehaviour enemyBehaviour;
            public float activationSeconds;
        }

        /*
        private void Start()
        {
            StartCoroutine()
        }
        
        private IEnumerator */
    }
}