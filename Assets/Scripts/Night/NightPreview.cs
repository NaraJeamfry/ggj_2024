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
        private List<NpcType> _audience;
        public List<Guest> guests;
        public Dictionary<NpcType, int> AudienceStats { get; private set; }

        public List<NpcType> Audience
        {
            get => _audience;
            set
            {
                _audience = value;
                AudienceStats = new Dictionary<NpcType, int>(); // Restart the dictionary
                foreach (NpcType person in _audience)
                {
                    AudienceStats.TryAdd(person, 0);

                    AudienceStats[person] += 1;
                }
            }
        }
    }
}