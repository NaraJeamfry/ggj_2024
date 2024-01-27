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

        public int money;
        public int renown;
        public int stamina;
        public int laughPoints;
        public string nightScene;
        public string resultsScene;

        public bool Paused => _paused;
        [SerializeField] private bool _paused;

        private NightManager _nightManager;

        public void SetNightManager(NightManager newNightManager)
        {
            _nightManager = newNightManager;
            _nightManager.StartNight(currentNight);
        }

        public void StartNight()
        {
            if (_nightManager is null || !_nightManager.nightOngoing)
            {
                SceneManager.LoadScene(nightScene, LoadSceneMode.Single);
            }
        }
        
        private void Update()
        {
            
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
            _paused = true;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
            _paused = false;
        }

        public void UpdateResources(ResourceUpdates updates)
        {
            money += updates.moneyChange;
            renown += updates.renownChange;
            stamina += updates.staminaChange;
            laughPoints += updates.laughChange;
        }
        
        public void FinishNight()
        {
            Debug.Log($"Night finished with {laughPoints} points");
            SceneManager.LoadScene(resultsScene, LoadSceneMode.Single);
            _nightManager = null;
        }
    }
}
