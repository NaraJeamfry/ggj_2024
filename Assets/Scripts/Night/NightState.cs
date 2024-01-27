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
        public ShowActivityWithTheme[] showActivities;

        public ShowTheme[] NightThemes
        {
            get
            {
                return nightThemes;
            }
        }

        public ShowActivityWithTheme[] ShowActivities
        {
            get
            {
                return showActivities;
            }
        }
    }
}