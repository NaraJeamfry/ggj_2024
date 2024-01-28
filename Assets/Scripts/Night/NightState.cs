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
        public ShowActivity[] showActivities;

        public NightPreview preview;

        public ShowTheme[] NightThemes
        {
            get
            {
                return nightThemes;
            }
        }

        public ShowActivity[] ShowActivities
        {
            get
            {
                return showActivities;
            }
        }
    }
}