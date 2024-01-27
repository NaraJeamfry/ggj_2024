using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Night
{
    public class NightUIManager : MonoBehaviour
    {
        public TMP_Text activityName;
        public TMP_Text percent;

        public NightManager nightManager;

        private void Start()
        {
            nightManager = GetComponent<NightManager>();
        }

        private void Update()
        {
            percent.text = $"Progress: {nightManager.NightProgress * 100}";
            activityName.text = $"Ongoing: {nightManager.currentActivity.activityName}";
        }
    }
}