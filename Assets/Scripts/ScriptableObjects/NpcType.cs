using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "NPC/NPC Type")]
    public class NpcType : ScriptableObject
    {
        public Sprite person;
        public string typeName;
        public List<ShowTheme> favoriteThemes;
        public List<ShowTheme> hateThemes;
    }
}