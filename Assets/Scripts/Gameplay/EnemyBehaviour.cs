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
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public virtual void Attack()
        {
            if (!IsActive) return;
            ServiceLocator.Instance.GetService<IPlayerHealth>().TakeDamage();
            _animator.SetBool("Attack", true);
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
            _animator.SetBool("Death", true);/*
            gameObject.SetActive(false);*/
        }

        public virtual void Activate()
        {
            CurrentPoints = maxPoints;
            IsActive = true;
        }
    }
}