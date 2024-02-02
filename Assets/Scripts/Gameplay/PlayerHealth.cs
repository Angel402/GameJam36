using System;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

namespace Gameplay
{
    public class PlayerHealth : MonoBehaviour, IPlayerHealth
    {
        [SerializeField] private Light playerLight;

        [Serializable]
        public class HealthBar
        {
            /*public int id;*/
            public float lightIntensity;
            public GameObject healthImage;
        }

        [SerializeField] private List<HealthBar> healthBars;
        private int _currentHealthBar;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<IPlayerHealth>(this);
            _currentHealthBar = healthBars.Count - 1;
        }

        public void TakeDamage()
        {
            Debug.Log("take damage");
            healthBars[_currentHealthBar].healthImage.SetActive(false);
            _currentHealthBar--;
            playerLight.intensity = healthBars[_currentHealthBar].lightIntensity;
            if (_currentHealthBar <= 0) Death();
        }

        public void RestoreHealth()
        {
            if (_currentHealthBar > healthBars.Count - 2) return;
            _currentHealthBar++;
            playerLight.intensity = healthBars[_currentHealthBar].lightIntensity;
            healthBars[_currentHealthBar].healthImage.SetActive(true);
        }

        private void Death()
        {
            throw new NotImplementedException();
        }
    }
}