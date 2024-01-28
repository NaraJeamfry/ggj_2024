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
        public bool waitingChoice;

        /// <summary>
        /// Activity to auto-schedule if missing activities.
        /// </summary>
        public ShowActivity idleActivity;

        public NightChoices nightChoices;

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
            
            // Add activities to NightChoices
            nightChoices.InitializeWithActivities(nightState.ShowActivities);
            
            // Enqueue all activities
            new List<NightSlot>(nightState.ShowActivities).ForEach(_nightActivities.Enqueue);
            
            Debug.Log($"[NightManager] Starting new night. Will manage state on next Update.");
        }

        private void UpdateActivity()
        {
            activityTimer += Time.deltaTime;
        }

        private void FinishActivity()
        {
            Debug.Log($"[NightManager] Finishing activity {currentActivity.activityName}");
            
            activityTimer = 0.0f;
            counter += currentActivity.length;
                
            IExtras extras = ExtraEffectFactory.CreateExtra(currentActivity.extraEffects);

            extras?.ApplyExtras(currentActivity, this);

            ActivityResults();
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

        private void NextActivity()
        {
            Debug.Log($"[NightManager] Ready for next activity.");
            
            // Mark as waiting for activity. Will be unset by the callbacks.
            waitingChoice = true;

            // Old code equivalent (choose from pre-set array):

            // ChooseActivity(_nightActivities.Dequeue().Activity);
        }

        public void ChooseActivity(ShowActivity activity)
        {
            if (!waitingChoice)
            {
                Debug.Log("Tried to choose an activity but we're not expecting a choice now.");
                return;
            }
            
            currentActivity = activity;
            
            readyToAdvance = false;
            waitingChoice = false;
            
            Debug.Log($"[NightManager] Next activity: {currentActivity.activityName}.");
        } 

        private void Update()
        {
            if (waitingChoice)
            {
                return;
            }
            
            if (!readyToAdvance && activityTimer <= currentActivity.length * slotDuration)
            {
                // Update running activity
                UpdateActivity();
            }
            else 
            {
                if (currentActivity is not null)
                {
                    // Activity just finished. Do things!
                    FinishActivity();
                }
                
                if (counter >= slotCount)
                {
                    Debug.Log($"[NightManager] Finished the slots! Ending the night.");
                    _gameManager.FinishNight();
                }

                NextActivity();
            }
        }
    }
}