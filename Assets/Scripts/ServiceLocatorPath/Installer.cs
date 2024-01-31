using Gameplay;
using UnityEngine;

namespace ServiceLocatorPath
{
    public class Installer : MonoBehaviour
    {
        /*private ScoreService _scoreService;*/
        private void Awake()
        {
            if (FindObjectsOfType<Installer>().Length > 1)
            {
                Destroy(gameObject);
                return;
            }
            /*_scoreService = new ScoreService();*/
            /*ServiceLocator.Instance.RegisterService<IScoreService>(_scoreService);*/
        }   
    }
}