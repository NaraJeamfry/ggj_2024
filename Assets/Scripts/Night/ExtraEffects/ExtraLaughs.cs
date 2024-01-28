using System;
using Interfaces;
using Managers;
using ScriptableObjects;
using UnityEngine;

namespace Night.ExtraEffects
{
    public class ExtraLaughs : IExtras
    {
        public void ApplyExtras(ShowActivity activity, NightManager nightManager)
        {
            NightPreview state = nightManager.nightState.preview;
            ResourceUpdates resources = new ResourceUpdates();

            foreach (NpcType personType in state.AudienceStats.Keys)
            {
                float laughMultiplier = 1;
                
                foreach (ShowTheme theme in activity.themes)
                {
                    if (personType.favoriteThemes.Contains(theme))
                    {
                        laughMultiplier += Math.Max(laughMultiplier, 1);
                    } else if (personType.hateThemes.Contains(theme))
                    {
                        laughMultiplier -= Math.Max(laughMultiplier * 0.5f, 1);
                    }
                }

                resources.laughChange += (int)Math.Ceiling(activity.laughPoints * laughMultiplier * state.AudienceStats[personType]);
            }
            
            GameManager manager = GameManager.Instance;
            manager.UpdateResources(resources);
        }
    }
}