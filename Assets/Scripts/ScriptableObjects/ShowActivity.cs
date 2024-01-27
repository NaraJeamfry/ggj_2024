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
        public float repetitionWear = 0.5f;
        public EExtraEffects extraEffects;
        public bool needsChoice;

        public ResourceUpdates updates;
    }
}