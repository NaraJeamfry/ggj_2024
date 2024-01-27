using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Night
{
    public class NightChoices : MonoBehaviour
    {
        public struct Choice
        {
            public string ChoiceName;
            public object Value;
        }

        public List<Button> buttons = new List<Button>();

        public GameObject buttonPrefab;
        public NightManager nightManager;
        
        public void InitializeWithActivities(NightSlot[] activities)
        {
            foreach (NightSlot slot in activities)
            {
                Button newButton = Instantiate(buttonPrefab, transform).GetComponent<Button>();
                newButton.onClick.AddListener(() =>
                {
                    nightManager.ChooseActivity(slot.Activity);
                });
                newButton.GetComponentInChildren<TMP_Text>().text = slot.Activity.activityName;
                buttons.Add(newButton);
            }
        }

    }
}