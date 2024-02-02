using System;
using ServiceLocatorPath;
using UnityEngine;

namespace Gameplay
{
    public abstract class EnemyBehaviour : MonoBehaviour
    {
        public Action OnDeath;
        [SerializeField] protected int health;
        [SerializeField] protected float maxPoints;
        [SerializeField] protected float attackSeconds;
        protected float CurrentPoints;
        protected bool IsActive = false ;

        public virtual void Attack()
        {
            ServiceLocator.Instance.GetService<IPlayerHealth>().TakeDamage();
            IsActive = false;
        }
        public virtual void GetDamage()
        {
            health--;
            if (health <= 0)
            {
                Death();
            }
        }
    

        public virtual void Death()
        {
            IsActive = false;
            ServiceLocator.Instance.GetService<IScoreService>().AddScore(CurrentPoints);
            gameObject.SetActive(false);
        }

        public virtual void Activate()
        {
            CurrentPoints = maxPoints;
            IsActive = true;
        }
    }
}