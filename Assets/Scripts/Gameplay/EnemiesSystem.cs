//Deprecated
using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

namespace Gameplay
{
    public class EnemiesSystem : MonoBehaviour
    {
        [Serializable]
        public class Enemy
        {
            public EnemyBehaviour enemyBehaviour;
            public float activationSeconds;
            public float attackSeconds;
            public float maxPoints;
            public float timeLeftToAttack;
            public float currentPoints;
            public bool isActive = false ;
        }

        [SerializeField] private List<Enemy> enemies;

        private void Start()
        {
            StartCoroutine(StartEnemySystem());
        }

        private IEnumerator StartEnemySystem()
        {
            foreach (var enemy in enemies)
            {
                yield return new WaitForSeconds(enemy.activationSeconds);
                enemy.isActive = true;
                enemy.timeLeftToAttack = enemy.attackSeconds;
                enemy.currentPoints = enemy.maxPoints;
                enemy.enemyBehaviour.OnDeath += () =>
                {
                    enemy.isActive = false;
                    ServiceLocator.Instance.GetService<IScoreService>().AddScore(enemy.currentPoints);
                };
            }
        }

        private void Update()
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.isActive) continue;
                enemy.currentPoints -= enemy.maxPoints * Time.deltaTime / enemy.attackSeconds;
                enemy.timeLeftToAttack -= Time.deltaTime;
                if (enemy.timeLeftToAttack <= 0)
                {
                    enemy.enemyBehaviour.Attack();
                    enemy.isActive = false;
                }
            }
        }
    }
}