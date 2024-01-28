using System;
using System.Collections.Generic;
using Night;
using ScriptableObjects;

namespace Managers
{
    public static class RoundInitializer
    {
        public static NightPreview GenerateRound(int levelSeed, GameSettings settings)
        {
            Random random = new Random(levelSeed);
            
            NightPreview result = new NightPreview();

            result.settings = GenerateRoundSettings(random, settings);
            result.Audience = GenerateAudience(random, result.settings);

            return result;
        }

        private static RoundSettings GenerateRoundSettings(Random random, GameSettings settings)
        {
            RoundSettings result = new RoundSettings();
            List<NpcType> selectedTypes = new();
            List<NpcType> availableTypes = new List<NpcType>(settings.npcTypes);

            for (int i = 0; i < settings.npcTypeCount; i++)
            {
                if (availableTypes.Count == 0)
                    break;
                
                int chosen = random.Next() % availableTypes.Count;
                selectedTypes.Add(availableTypes[chosen]);
                availableTypes.RemoveAt(chosen);
            }

            result.validTypes = selectedTypes;
            
            return result;
        }

        private static List<NpcType> GenerateAudience(Random random, RoundSettings settings)
        {
            List<NpcType> result = new List<NpcType>();

            for (int i = 0; i < 100; i++)
            {
                result.Add(settings.validTypes[random.Next(settings.validTypes.Count)]);
            }

            return result;
        }
    }
}