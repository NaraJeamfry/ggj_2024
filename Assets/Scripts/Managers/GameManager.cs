using System;
using Night;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
using Random = System.Random;

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
        public GameSettings gameSettings;

        public bool Paused => _paused;
        [SerializeField] private bool _paused;

        public int initialSeed = 0;
        public bool startRandom = false;
        private Random _dailyRandomizer;

        private NightManager _nightManager;

        public NightPreview preview;

        private void Start()
        {
            if (startRandom)
                initialSeed = Environment.TickCount;
            _dailyRandomizer = new Random(initialSeed);

            preview = RoundInitializer.GenerateRound(_dailyRandomizer.Next(), gameSettings);
        }

        public void SetNightManager(NightManager newNightManager)
        {
            _nightManager = newNightManager;
            currentNight.preview = preview;
            _nightManager.StartNight(currentNight);
        }

        public void StartNight()
        {
            if (_nightManager is null || !_nightManager.nightOngoing)
            {
                SceneManager.LoadScene(nightScene, LoadSceneMode.Single);
            }
        }

        public void StartPreparing()
        {
            SceneManager.LoadScene("PreparationScene", LoadSceneMode.Single);
        }

        public void FinishPreparing(NightState state)
        {
            currentNight = state;
            StartNight();
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
