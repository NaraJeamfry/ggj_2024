using System.Collections.Generic;
using Enums;
using Interfaces;
using Night;
using UnityEditor;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Show/Show Activity")]
    public class ShowActivity : ScriptableObject
    {
        public int length = 1;
        public string activityName;
        public EActivityTypes type = EActivityTypes.None;
        
        public float repetitionWear = 0.5f;
        public EExtraEffects extraEffects;
        public bool needsChoice;
        
        public int moneyCost = 0;
        public int energyCost = 0;
        public int neededReputation = 0;

        public ResourceUpdates updates;
        
        public int laughPoints = 0;
        public bool available = true;

        public List<ShowTheme> themes;
    }
    
    
}