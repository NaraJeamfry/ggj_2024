using System;
using Night;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public NightState currentNight;

        public int laughPoints;
        public string nightScene;
        public string resultsScene;

        private NightManager _nightManager;

        public void SetNightManager(NightManager newNightManager)
        {
            _nightManager = newNightManager;
            _nightManager.StartNight(currentNight);
        }

        private void Start()
        {
            SceneManager.LoadScene(nightScene, LoadSceneMode.Single);
        }
        
        private void Update()
        {
            
        }
        
        public void FinishNight()
        {
            Debug.Log($"Night finished with {laughPoints} points");
            SceneManager.LoadScene(resultsScene, LoadSceneMode.Single);
            _nightManager = null;
        }
    }
}
