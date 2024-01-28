using System;
using System.Collections.Generic;
using ScriptableObjects;

namespace Managers
{
    [Serializable]
    public class GameSettings
    {
        public List<NpcType> npcTypes;
        public List<Guest> guests;
        public int npcTypeCount;
    }
}