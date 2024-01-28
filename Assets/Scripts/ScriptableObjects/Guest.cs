using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "NPC/Guest")]
    public class Guest : ScriptableObject
    {
        public Sprite sprite;
        public string guestName;
    }
}