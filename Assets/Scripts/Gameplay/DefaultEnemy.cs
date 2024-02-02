using System;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class DefaultEnemy : EnemyBehaviour
    {
        private void Update()
        {
            if(!IsActive) return;
            CurrentPoints -= maxPoints * Time.deltaTime / attackSeconds;
        }
    }
}