using System;
using Gameplay;
using TMPro;
using UnityEngine;

namespace ServiceLocatorPath
{
    public class ScoreService : MonoBehaviour, IScoreService
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private float _currentScore;

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService<IScoreService>(this);
        }

        public void AddScore(float score)
        {
            _currentScore += (int)score;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            scoreText.text = _currentScore.ToString();
        }
    }
}