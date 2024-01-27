using System;
using System.Collections.Generic;
using Managers;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Night
{
    public class NightManager : MonoBehaviour
    {
        public NightState nightState;
        public bool readyToAdvance;
        public bool nightOngoing = false;
        public int startTime = 18;
        public int counter = 0;
        public int slotCount = 8;
        public ShowActivity currentActivity;
        public float activityTimer;
        public float slotDuration = 5.0f;

        /// <summary>
        /// Activity to auto-schedule if missing activities.
        /// </summary>
        public ShowActivity idleActivity;

        private GameManager _gameManager;
        private Queue<ShowActivityWithTheme> _nightActivities;

        public int CurrentTime => (startTime + counter) % 24;
        public float NightProgress => (counter + activityTimer / slotDuration) / slotCount;

        protected virtual void Start()
        {
            _gameManager = GameManager.Instance;
            _nightActivities = new Queue<ShowActivityWithTheme>();
            
            _gameManager.SetNightManager(this);
        }

        public void StartNight(NightState newNightState)
        {
            if (nightOngoing)
            {
                throw new Exception("Tried to start a night when one is already ongoing.");
            }

            nightState = newNightState;
            nightOngoing = true;
            readyToAdvance = true;
            
            // Enqueue all activities
            new List<ShowActivityWithTheme>(nightState.ShowActivities).ForEach(_nightActivities.Enqueue);
            
            Debug.Log($"[NightManager] Starting new night. Will manage state on next Update.");
        }

        private void Update()
        {
            if (!readyToAdvance && activityTimer <= currentActivity.length * slotDuration)
            {
                activityTimer += Time.deltaTime;
                
                // Just wait until current tick finishes.
                return;
            }
            
            Debug.Log($"[NightManager] Ready for next activity.");

            if (currentActivity is not null) counter += currentActivity.length;
            
            if (counter >= slotCount)
            {
                _gameManager.FinishNight();
            }
            
            // No activities scheduled. Auto-schedule idle activity.
            currentActivity = _nightActivities.Count == 0 ? idleActivity : _nightActivities.Dequeue().Activity;
            
            activityTimer = 0.0f;
            readyToAdvance = false;
            
            Debug.Log($"[NightManager] Next activity: {currentActivity.activityName}.");
        }
    }
}