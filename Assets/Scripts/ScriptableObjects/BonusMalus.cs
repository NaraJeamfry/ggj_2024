using Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Effects/Bonus&Malus")]
    public class BonusMalus : ScriptableObject
    {
        public Sprite icon;
        public new string name;
        public EModifiers modifier;
        public float value;
    }
}