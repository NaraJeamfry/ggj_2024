using System;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjects;
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

        public List<NightChoicesButton> buttons;
        public Choice[] Choices;

        public GameObject buttonPrefab;

        public NightChoices(NightSlot slot)
        {
            buttons = new List<NightChoicesButton>();
            foreach (ShowTheme theme in slot.ChosenThemes)
            {
                NightChoicesButton newButton = Instantiate(buttonPrefab, transform).GetComponent<NightChoicesButton>();
                newButton.Action = () =>
                {
                    return;
                };
                buttons.Add(newButton);
            }
        }

    }
}