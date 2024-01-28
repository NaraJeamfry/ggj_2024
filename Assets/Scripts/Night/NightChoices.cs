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
        
        public void InitializeWithActivities(ShowActivity[] activities)
        {
            foreach (ShowActivity slot in activities)
            {
                Button newButton = Instantiate(buttonPrefab, transform).GetComponent<Button>();
                newButton.onClick.AddListener(() =>
                {
                    nightManager.ChooseActivity(slot);
                });
                newButton.GetComponentInChildren<TMP_Text>().text = slot.activityName;
                buttons.Add(newButton);
            }
        }

    }
}