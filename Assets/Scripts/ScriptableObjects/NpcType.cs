using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "NPC/NPC Type")]
    public class NpcType : ScriptableObject
    {
        public Sprite person;
        public string typeName;
    }
}