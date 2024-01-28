using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "NPCs/Guest")]
    public class Guest : ScriptableObject
    {
        public Sprite sprite;
        public string guestName;
    }
}