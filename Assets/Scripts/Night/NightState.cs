using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Night
{
    [Serializable]
    public class NightState
    {
        [SerializeField]
        public ShowTheme[] nightThemes;
        [SerializeField]
        public NightSlot[] showActivities;

        public ShowTheme[] NightThemes
        {
            get
            {
                return nightThemes;
            }
        }

        public NightSlot[] ShowActivities
        {
            get
            {
                return showActivities;
            }
        }
    }
}