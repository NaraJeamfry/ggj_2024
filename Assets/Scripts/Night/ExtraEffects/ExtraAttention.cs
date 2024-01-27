using Interfaces;
using UnityEngine;

namespace Night.ExtraEffects
{
    public class ExtraAttention : IExtras
    {
        public void ApplyExtras(NightManager nightManager)
        {
            Debug.Log($"[ExtraAttention] Gained extra attention.");
        }
    }
}