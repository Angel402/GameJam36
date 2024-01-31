using ServiceLocatorPath;
using UnityEngine.UI;

namespace Gameplay
{
    public class DefaultEnemy : EnemyBehaviour
    {
        public override void Attack()
        {
            ServiceLocator.Instance.GetService<IPlayerHealth>().TakeDamage();
        }

        public override void GetDamage()
        {
            health--;
            if (health <= 0)
            {
                Death();
            }
        }

        public override void Death()
        {
            OnDeath?.Invoke();
            gameObject.SetActive(false);
        }
    }
}