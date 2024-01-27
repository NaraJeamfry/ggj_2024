using System;
using System.Collections.Generic;
using Interfaces;
using Managers;
using Night.ExtraEffects;
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
        public ShowActivity lastActivity;
        public ShowActivity currentActivity;
        public float activityTimer;
        public float slotDuration = 5.0f;

        public GameObject choicesPrefab;
        public Transform choicesSpawn;

        /// <summary>
        /// Activity to auto-schedule if missing activities.
        /// </summary>
        public ShowActivity idleActivity;

        private GameManager _gameManager;
        private Queue<NightSlot> _nightActivities;

        public int CurrentTime => (startTime + counter) % 24;
        public float NightProgress => (counter + activityTimer / slotDuration) / slotCount;

        protected virtual void Start()
        {
            _gameManager = GameManager.Instance;
            _nightActivities = new Queue<NightSlot>();
            
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
            new List<NightSlot>(nightState.ShowActivities).ForEach(_nightActivities.Enqueue);
            
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

            if (currentActivity is not null)
            {
                Debug.Log($"[NightManager] Finishing activity {currentActivity.activityName}");
                counter += currentActivity.length;
                
                IExtras extras = ExtraEffectFactory.CreateExtra(currentActivity.extraEffects);

                if (extras is not null)
                {
                    extras.ApplyExtras(this);
                }

                ActivityResults();
            }
            
            if (counter >= slotCount)
            {
                Debug.Log($"[NightManager] Finished the slots! Ending the night.");
                _gameManager.FinishNight();
            }
            
            Debug.Log($"[NightManager] Ready for next activity.");
            
            // No activities scheduled. Auto-schedule idle activity.
            currentActivity = _nightActivities.Count == 0 ? idleActivity : _nightActivities.Dequeue().Activity;
            
            activityTimer = 0.0f;
            readyToAdvance = false;
            if (currentActivity.needsChoice)
            {
                _gameManager.PauseGame();
                NightChoices newChoices = Instantiate(choicesPrefab, choicesSpawn).GetComponent<NightChoices>();
            }
            
            Debug.Log($"[NightManager] Next activity: {currentActivity.activityName}.");
        }

        private void ActivityResults()
        {
            if (lastActivity is null)
            {
                _gameManager.UpdateResources(currentActivity.updates);
            }
            else
            {
                float resultWear = 1.0f;
                if (lastActivity.activityName == currentActivity.activityName)
                {
                    resultWear -= currentActivity.repetitionWear;
                }
                _gameManager.UpdateResources(currentActivity.updates.ApplyWear(resultWear));
            }
        }
    }
}