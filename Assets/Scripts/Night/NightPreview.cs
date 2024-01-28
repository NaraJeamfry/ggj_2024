using System;
using System.Collections.Generic;
using Managers;
using ScriptableObjects;

namespace Night
{
    [Serializable]
    public class NightPreview
    {
        public RoundSettings settings;
        public List<NpcType> audience;
        public List<Guest> guests;
    }
}